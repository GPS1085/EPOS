using EPOS.Application.Common.Interfaces;
using EPOS.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using OrganizationEntity = EPOS.Domain.Entities.Organization;

namespace EPOS.Persistence.Repositories.Organizations;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly EPOSDbContext _context;

    public OrganizationRepository(EPOSDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(string code)
    {
        return await _context.Organizations
            .AnyAsync(x => x.Code.ToLower() == code.ToLower());
    }

    public async Task AddAsync(OrganizationEntity organization)
    {
        await _context.Organizations.AddAsync(organization);
    }

    public async Task<List<OrganizationEntity>> GetAllAsync()
    {
        return await _context.Organizations
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<OrganizationEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Organizations
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}