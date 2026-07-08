using EPOS.Application.Common.Interfaces;
using EPOS.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using StateEntity = EPOS.Domain.Entities.State;

namespace EPOS.Persistence.Repositories.States;

public class StateRepository : IStateRepository
{
    private readonly EPOSDbContext _context;

    public StateRepository(EPOSDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(string code)
    {
        return await _context.States
            .AnyAsync(x => x.Code.ToLower() == code.ToLower());
    }

    public async Task AddAsync(StateEntity state)
    {
        await _context.States.AddAsync(state);
    }

    public async Task<List<StateEntity>> GetAllAsync()
    {
        return await _context.States
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<StateEntity?> GetByIdAsync(Guid id)
    {
        return await _context.States
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}