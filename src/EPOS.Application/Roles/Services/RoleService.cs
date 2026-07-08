using EPOS.Application.Common.Interfaces;
using EPOS.Application.Roles.DTOs;
using EPOS.Application.Roles.Interfaces;
using EPOS.Domain.Entities;

namespace EPOS.Application.Roles.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<CreateRoleResponse> CreateRoleAsync(CreateRoleRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return new CreateRoleResponse
            {
                Success = false,
                Message = "Role Name is required."
            };
        }

        if (await _roleRepository.ExistsAsync(request.Name))
        {
            return new CreateRoleResponse
            {
                Success = false,
                Message = "Role already exists."
            };
        }

        var role = new Role
        {
            Name = request.Name,
            Description = request.Description,
            IsSystemRole = request.IsSystemRole,
            IsActive = request.IsActive
        };

        await _roleRepository.AddAsync(role);

        await _roleRepository.SaveChangesAsync();

        return new CreateRoleResponse
        {
            Success = true,
            RoleId = role.Id,
            Message = "Role created successfully."
        };
    }

    public async Task<List<RoleResponse>> GetAllRolesAsync()
    {
        var roles = await _roleRepository.GetAllAsync();

        return roles.Select(role => new RoleResponse
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description,
            IsSystemRole = role.IsSystemRole,
            IsActive = role.IsActive
        }).ToList();
    }
}