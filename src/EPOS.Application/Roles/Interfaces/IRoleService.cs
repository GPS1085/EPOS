using EPOS.Application.Roles.DTOs;

namespace EPOS.Application.Roles.Interfaces;

public interface IRoleService
{
    Task<CreateRoleResponse> CreateRoleAsync(CreateRoleRequest request);

    Task<List<RoleResponse>> GetAllRolesAsync();
}