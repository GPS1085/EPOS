using EPOS.Domain.Entities;

namespace EPOS.Application.Common.Interfaces;

public interface IPermissionRepository
{
    Task<bool> ExistsAsync(string code);

    Task AddAsync(Permission permission);

    Task<List<Permission>> GetAllAsync();

    Task SaveChangesAsync();
}