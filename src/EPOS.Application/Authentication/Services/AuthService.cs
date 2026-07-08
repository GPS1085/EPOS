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

        // Account inactive
        if (!user.IsActive)
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Your account is inactive."
            };
        }

        // Account locked
        if (user.IsLocked)
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Your account has been locked."
            };
        }

        // Verify Password
        if (!_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Invalid Login ID or Password."
            };
        }

        // Build JWT User Info
        var jwtUser = new JwtUserInfo
        {
            UserId = user.Id,
            OrganizationId = user.OrganizationId,
            EmployeeCode = user.EmployeeCode,
            Email = user.Email,
            MobileNumber = user.MobileNumber,
            UserType = user.UserType.ToString(),
            Roles = user.UserRoles
                        .Where(x => x.Role != null)
                        .Select(x => x.Role!.Name)
                        .ToList()
        };

        // Generate JWT
        var token = _jwtService.GenerateToken(jwtUser);

        // Update Last Login
        user.LastLoginOn = DateTime.UtcNow;

        await _userRepository.SaveChangesAsync();

        return new LoginResponse
        {
            Success = true,
            Token = token,
            RefreshToken = string.Empty,
            Expiry = DateTime.UtcNow.AddMinutes(60), // We'll improve this later
            Message = "Login successful."
        };
    }
}