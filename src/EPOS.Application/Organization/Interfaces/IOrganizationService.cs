using EPOS.Application.Organization.DTOs;

namespace EPOS.Application.Organization.Interfaces;

public interface IOrganizationService
{
    Task<CreateOrganizationResponse> CreateAsync(CreateOrganizationRequest request);

    Task<List<OrganizationResponse>> GetAllAsync();

    Task<OrganizationResponse?> GetByIdAsync(Guid id);
}