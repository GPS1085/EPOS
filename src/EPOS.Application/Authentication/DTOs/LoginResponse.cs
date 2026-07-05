namespace EPOS.Application.Authentication.DTOs;

public class LoginResponse
{
    public bool Success { get; set; }

    public string Token { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public DateTime Expiry { get; set; }

    public string Message { get; set; } = string.Empty;
}