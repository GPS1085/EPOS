using EPOS.Application.Users.DTOs;

namespace EPOS.Application.Users.Interfaces;

public interface IUserService
{
    Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request);

    Task<List<UserResponse>> GetAllUsersAsync();

    Task<UserResponse?> GetUserByIdAsync(Guid id);
    Task<bool> UpdateUserAsync(Guid id, UpdateUserRequest request);
    Task<bool> ActivateUserAsync(Guid id);

    Task<bool> DeactivateUserAsync(Guid id);
}