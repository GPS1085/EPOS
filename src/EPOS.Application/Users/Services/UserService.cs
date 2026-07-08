using System.Linq;
using EPOS.Application.Authentication.Interfaces;
using EPOS.Application.Common.Interfaces;
using EPOS.Application.Users.DTOs;
using EPOS.Application.Users.Interfaces;
using EPOS.Domain.Entities;

namespace EPOS.Application.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.FirstName))
        {
            return new CreateUserResponse
            {
                Success = false,
                Message = "First Name is required."
            };
        }

        if (string.IsNullOrWhiteSpace(request.Email))
        {
            return new CreateUserResponse
            {
                Success = false,
                Message = "Email is required."
            };
        }

        if (string.IsNullOrWhiteSpace(request.MobileNumber))
        {
            return new CreateUserResponse
            {
                Success = false,
                Message = "Mobile Number is required."
            };
        }

        if (string.IsNullOrWhiteSpace(request.Password))
        {
            return new CreateUserResponse
            {
                Success = false,
                Message = "Password is required."
            };
        }

        if (await _userRepository.EmailExistsAsync(request.Email))
        {
            return new CreateUserResponse
            {
                Success = false,
                Message = "Email already exists."
            };
        }

        if (await _userRepository.MobileExistsAsync(request.MobileNumber))
        {
            return new CreateUserResponse
            {
                Success = false,
                Message = "Mobile Number already exists."
            };
        }

        var employeeCode = $"EMP{DateTime.UtcNow:yyyyMMddHHmmss}";

        var user = new User
        {
            OrganizationId = request.OrganizationId,
            EmployeeCode = employeeCode,
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            LastName = request.LastName,
            Email = request.Email,
            MobileNumber = request.MobileNumber,
            PasswordHash = _passwordHasher.HashPassword(request.Password),
            ProfilePhotoUrl = request.ProfilePhotoUrl,
            IsActive = true,
            IsFirstLogin = true
        };

        await _userRepository.AddAsync(user);

        await _userRepository.AddUserRoleAsync(new UserRole
        {
            UserId = user.Id,
            RoleId = request.RoleId
        });

        await _userRepository.SaveChangesAsync();

        return new CreateUserResponse
        {
            Success = true,
            UserId = user.Id,
            Message = "User created successfully."
        };
    }

    public async Task<List<UserResponse>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();

        return users.Select(user => new UserResponse
        {
            Id = user.Id,
            EmployeeCode = user.EmployeeCode,
            FullName = user.FullName,
            Email = user.Email,
            MobileNumber = user.MobileNumber,
            IsActive = user.IsActive,
            UserType = user.UserType.ToString(),
            LastLoginOn = user.LastLoginOn
        }).ToList();
    }

    public async Task<UserResponse?> GetUserByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return null;

        return new UserResponse
        {
            Id = user.Id,
            EmployeeCode = user.EmployeeCode,
            FullName = user.FullName,
            Email = user.Email,
            MobileNumber = user.MobileNumber,
            IsActive = user.IsActive,
            UserType = user.UserType.ToString(),
            LastLoginOn = user.LastLoginOn
        };
    }

    public async Task<bool> UpdateUserAsync(Guid id, UpdateUserRequest request)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return false;

        user.FirstName = request.FirstName;
        user.MiddleName = request.MiddleName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.MobileNumber = request.MobileNumber;
        user.ProfilePhotoUrl = request.ProfilePhotoUrl;
        user.IsActive = request.IsActive;
        user.ModifiedOn = DateTime.UtcNow;

        await _userRepository.SaveChangesAsync();

        return true;
    }
    public async Task<bool> ActivateUserAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return false;

        user.IsActive = true;
        user.ModifiedOn = DateTime.UtcNow;

        await _userRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeactivateUserAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return false;

        user.IsActive = false;
        user.ModifiedOn = DateTime.UtcNow;

        await _userRepository.SaveChangesAsync();

        return true;
    }
}