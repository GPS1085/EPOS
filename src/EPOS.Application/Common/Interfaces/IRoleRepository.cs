using EPOS.Domain.Entities;

namespace EPOS.Application.Common.Interfaces;

public interface IRoleRepository
{
    Task<bool> ExistsAsync(string roleName);

    Task AddAsync(Role role);

    Task<List<Role>> GetAllAsync();

    Task SaveChangesAsync();
}