using EPOS.Application.Common.Interfaces;
using EPOS.Domain.Entities;
using EPOS.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EPOS.Persistence.Repositories.Permissions;

public class PermissionRepository : IPermissionRepository
{
    private readonly EPOSDbContext _context;

    public PermissionRepository(EPOSDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(string code)
    {
        return await _context.Permissions
            .AnyAsync(x => x.Code.ToLower() == code.ToLower());
    }

    public async Task AddAsync(Permission permission)
    {
        await _context.Permissions.AddAsync(permission);
    }

    public async Task<List<Permission>> GetAllAsync()
    {
        return await _context.Permissions
            .OrderBy(x => x.Module)
            .ThenBy(x => x.Name)
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}