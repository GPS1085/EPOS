using OrganizationEntity = EPOS.Domain.Entities.Organization;

namespace EPOS.Application.Common.Interfaces;

public interface IOrganizationRepository
{
    Task<bool> ExistsAsync(string code);

    Task AddAsync(OrganizationEntity organization);

    Task<List<OrganizationEntity>> GetAllAsync();

    Task<OrganizationEntity?> GetByIdAsync(Guid id);

    Task SaveChangesAsync();
}