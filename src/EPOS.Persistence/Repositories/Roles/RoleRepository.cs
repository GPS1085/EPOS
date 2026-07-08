using EPOS.Application.Common.Interfaces;
using EPOS.Domain.Entities;
using EPOS.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EPOS.Persistence.Repositories.Roles;

public class RoleRepository : IRoleRepository
{
    private readonly EPOSDbContext _context;

    public RoleRepository(EPOSDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(string roleName)
    {
        return await _context.Roles
            .AnyAsync(x => x.Name.ToLower() == roleName.ToLower());
    }

    public async Task AddAsync(Role role)
    {
        await _context.Roles.AddAsync(role);
    }

    public async Task<List<Role>> GetAllAsync()
    {
        return await _context.Roles
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}