namespace ExpenseTracker.Api.Models.Dto;

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public UserInfoResponse UserInfo { get; set; } = new();
}