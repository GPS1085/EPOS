using EPOS.Application.Common.Interfaces;
using EPOS.Application.Organization.DTOs;
using EPOS.Application.Organization.Interfaces;
using OrganizationEntity = EPOS.Domain.Entities.Organization;

namespace EPOS.Application.Organization.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _organizationRepository;

    public OrganizationService(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public async Task<CreateOrganizationResponse> CreateAsync(CreateOrganizationRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return new CreateOrganizationResponse
            {
                Success = false,
                Message = "Organization Name is required."
            };
        }

        if (string.IsNullOrWhiteSpace(request.Code))
        {
            return new CreateOrganizationResponse
            {
                Success = false,
                Message = "Organization Code is required."
            };
        }

        if (await _organizationRepository.ExistsAsync(request.Code))
        {
            return new CreateOrganizationResponse
            {
                Success = false,
                Message = "Organization Code already exists."
            };
        }

        var organization = new OrganizationEntity
        {
            Name = request.Name,
            Code = request.Code,
            IsActive = true
        };

        await _organizationRepository.AddAsync(organization);
        await _organizationRepository.SaveChangesAsync();

        return new CreateOrganizationResponse
        {
            Success = true,
            OrganizationId = organization.Id,
            Message = "Organization created successfully."
        };
    }

    public async Task<List<OrganizationResponse>> GetAllAsync()
    {
        var organizations = await _organizationRepository.GetAllAsync();

        return organizations.Select(x => new OrganizationResponse
        {
            Id = x.Id,
            Name = x.Name,
            Code = x.Code,
            IsActive = x.IsActive
        }).ToList();
    }

    public async Task<OrganizationResponse?> GetByIdAsync(Guid id)
    {
        var organization = await _organizationRepository.GetByIdAsync(id);

        if (organization == null)
            return null;

        return new OrganizationResponse
        {
            Id = organization.Id,
            Name = organization.Name,
            Code = organization.Code,
            IsActive = organization.IsActive
        };
    }
}