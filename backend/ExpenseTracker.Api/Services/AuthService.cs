using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Api.Data;
using ExpenseTracker.Api.Models;
using ExpenseTracker.Api.Models.Dto;
using BCrypt.Net;

namespace ExpenseTracker.Api.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IJwtService _jwtService;

    public AuthService(ApplicationDbContext context, IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    public async Task<(bool Success, string Message, int? UserId)> RegisterAsync(RegisterRequest request)
    {
        try
        {
            // Check if username already exists
            var existingUserByUsername = await _context.Users
                .FirstOrDefaultAsync(u => u.Username.ToLower() == request.Username.ToLower());
            
            if (existingUserByUsername != null)
            {
                return (false, "Username already exists", null);
            }

            // Check if email already exists
            var existingUserByEmail = await _context.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == request.Email.ToLower());
            
            if (existingUserByEmail != null)
            {
                return (false, "Email already exists", null);
            }

            // Create new user
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return (true, "User registered successfully", user.Id);
        }
        catch (Exception ex)
        {
            return (false, $"Registration failed: {ex.Message}", null);
        }
    }

    public async Task<(bool Success, string Message, LoginResponse? Response)> LoginAsync(LoginRequest request)
    {
        try
        {
            // Find user by username
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username.ToLower() == request.Username.ToLower());

            if (user == null)
            {
                return (false, "Invalid username or password", null);
            }

            // Verify password
            if (!VerifyPassword(request.Password, user.PasswordHash))
            {
                return (false, "Invalid username or password", null);
            }

            // Generate JWT token
            var token = _jwtService.GenerateToken(user);

            var response = new LoginResponse
            {
                Token = token,
                UserInfo = new UserInfoResponse
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    CreatedAt = user.CreatedAt
                }
            };

            return (true, "Login successful", response);
        }
        catch (Exception ex)
        {
            return (false, $"Login failed: {ex.Message}", null);
        }
    }

    public async Task<User?> GetUserByIdAsync(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }

    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
    }
}