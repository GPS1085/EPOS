using StateEntity = EPOS.Domain.Entities.State;

namespace EPOS.Application.Common.Interfaces;

public interface IStateRepository
{
    Task<bool> ExistsAsync(string code);

    Task AddAsync(StateEntity state);

    Task<List<StateEntity>> GetAllAsync();

    Task<StateEntity?> GetByIdAsync(Guid id);

    Task SaveChangesAsync();
}