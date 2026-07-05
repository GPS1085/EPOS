using EPOS.Application.Authentication.DTOs;
using EPOS.Application.Authentication.Interfaces;
using EPOS.Application.Common.Interfaces;

namespace EPOS.Application.Authentication.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;

    public AuthService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtService jwtService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        // Validate Login ID
        if (string.IsNullOrWhiteSpace(request.LoginId))
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Login ID is required."
            };
        }

        // Validate Password
        if (string.IsNullOrWhiteSpace(request.Password))
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Password is required."
            };
        }

        // Find User
        var user = await _userRepository.GetByEmailOrMobileAsync(request.LoginId);

        if (user == null)
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Invalid Login ID or Password."
            };
        }

        // Check if account is active
        if (!user.IsActive)
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Your account is inactive. Please contact Administrator."
            };
        }

        // Check if account is locked
        if (user.IsLocked)
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Your account has been locked. Please contact Administrator."
            };
        }

        // Verify Password
        bool passwordValid =
            _passwordHasher.VerifyPassword(
                request.Password,
                user.PasswordHash);

        if (!passwordValid)
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Invalid Login ID or Password."
            };
        }

        // JWT Generation comes next
        return new LoginResponse
        {
            Success = false,
            Message = "Password verification successful."
        };
    }
}