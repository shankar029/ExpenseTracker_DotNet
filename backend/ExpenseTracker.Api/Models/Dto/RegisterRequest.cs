using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Api.Models.Dto;

public class RegisterRequest
{
    [Required(ErrorMessage = "Username is required")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 80 characters")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(120, ErrorMessage = "Email must not exceed 120 characters")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(255, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", 
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
    public string Password { get; set; } = string.Empty;
}