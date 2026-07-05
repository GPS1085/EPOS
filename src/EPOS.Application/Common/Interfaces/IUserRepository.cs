using EPOS.Domain.Entities;

namespace EPOS.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);

    Task<User?> GetByMobileAsync(string mobile);

    Task<User?> GetByEmailOrMobileAsync(string loginId);

    Task AddAsync(User user);

    Task SaveChangesAsync();
}