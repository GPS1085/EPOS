using EPOS.Application.States.DTOs;

namespace EPOS.Application.States.Interfaces;

public interface IStateService
{
    Task<CreateStateResponse> CreateAsync(CreateStateRequest request);

    Task<List<StateResponse>> GetAllAsync();

    Task<StateResponse?> GetByIdAsync(Guid id);
}