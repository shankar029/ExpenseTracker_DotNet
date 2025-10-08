using ExpenseTracker.Api.Models;
using ExpenseTracker.Api.Models.Dto;

namespace ExpenseTracker.Api.Services;

public interface IAuthService
{
    Task<(bool Success, string Message, int? UserId)> RegisterAsync(RegisterRequest request);
    Task<(bool Success, string Message, LoginResponse? Response)> LoginAsync(LoginRequest request);
    Task<User?> GetUserByIdAsync(int userId);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<User?> GetUserByEmailAsync(string email);
    bool VerifyPassword(string password, string hashedPassword);
    string HashPassword(string password);
}