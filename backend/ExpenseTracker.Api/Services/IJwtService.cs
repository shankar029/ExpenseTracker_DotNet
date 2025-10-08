using ExpenseTracker.Api.Models;
using System.Security.Claims;

namespace ExpenseTracker.Api.Services;

public interface IJwtService
{
    string GenerateToken(User user);
    ClaimsPrincipal? ValidateToken(string token);
    string? GetUserIdFromToken(string token);
}