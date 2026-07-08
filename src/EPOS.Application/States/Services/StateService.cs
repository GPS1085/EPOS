using EPOS.Application.Common.Interfaces;
using EPOS.Application.States.DTOs;
using EPOS.Application.States.Interfaces;
using StateEntity = EPOS.Domain.Entities.State;

namespace EPOS.Application.States.Services;

public class StateService : IStateService
{
    private readonly IStateRepository _repository;

    public StateService(IStateRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateStateResponse> CreateAsync(CreateStateRequest request)
    {
        if (await _repository.ExistsAsync(request.Code))
        {
            return new CreateStateResponse
            {
                Success = false,
                Message = "State Code already exists."
            };
        }

        var state = new StateEntity
        {
            OrganizationId = request.OrganizationId,
            Name = request.Name,
            Code = request.Code,
            IsActive = true
        };

        await _repository.AddAsync(state);
        await _repository.SaveChangesAsync();

        return new CreateStateResponse
        {
            Success = true,
            StateId = state.Id,
            Message = "State created successfully."
        };
    }

    public async Task<List<StateResponse>> GetAllAsync()
    {
        var states = await _repository.GetAllAsync();

        return states.Select(x => new StateResponse
        {
            Id = x.Id,
            OrganizationId = x.OrganizationId,
            Name = x.Name,
            Code = x.Code,
            IsActive = x.IsActive
        }).ToList();
    }

    public async Task<StateResponse?> GetByIdAsync(Guid id)
    {
        var state = await _repository.GetByIdAsync(id);

        if (state == null)
            return null;

        return new StateResponse
        {
            Id = state.Id,
            OrganizationId = state.OrganizationId,
            Name = state.Name,
            Code = state.Code,
            IsActive = state.IsActive
        };
    }
}