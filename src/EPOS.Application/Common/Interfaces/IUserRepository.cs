using EPOS.Domain.Entities;

namespace EPOS.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);

    Task<User?> GetByMobileAsync(string mobile);

    Task<User?> GetByEmailOrMobileAsync(string loginId);
    Task<List<User>> GetAllUsersAsync();

    Task<User?> GetByIdAsync(Guid id);

    Task AddAsync(User user);
    Task AddUserRoleAsync(UserRole userRole);

    Task SaveChangesAsync();
    Task<bool> EmailExistsAsync(string email);

    Task<bool> MobileExistsAsync(string mobile);
}