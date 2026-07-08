using EPOS.Application.Common.Interfaces;
using EPOS.Application.Permissions.DTOs;
using EPOS.Application.Permissions.Interfaces;
using EPOS.Domain.Entities;

namespace EPOS.Application.Permissions.Services;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _permissionRepository;

    public PermissionService(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<CreatePermissionResponse> CreatePermissionAsync(CreatePermissionRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Module))
        {
            return new CreatePermissionResponse
            {
                Success = false,
                Message = "Module is required."
            };
        }

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return new CreatePermissionResponse
            {
                Success = false,
                Message = "Permission Name is required."
            };
        }

        if (string.IsNullOrWhiteSpace(request.Code))
        {
            return new CreatePermissionResponse
            {
                Success = false,
                Message = "Permission Code is required."
            };
        }

        if (await _permissionRepository.ExistsAsync(request.Code))
        {
            return new CreatePermissionResponse
            {
                Success = false,
                Message = "Permission already exists."
            };
        }

        var permission = new Permission
        {
            Module = request.Module,
            Name = request.Name,
            Code = request.Code,
            Description = request.Description
        };

        await _permissionRepository.AddAsync(permission);
        await _permissionRepository.SaveChangesAsync();

        return new CreatePermissionResponse
        {
            Success = true,
            PermissionId = permission.Id,
            Message = "Permission created successfully."
        };
    }

    public async Task<List<PermissionResponse>> GetAllPermissionsAsync()
    {
        var permissions = await _permissionRepository.GetAllAsync();

        return permissions.Select(x => new PermissionResponse
        {
            Id = x.Id,
            Module = x.Module,
            Name = x.Name,
            Code = x.Code,
            Description = x.Description
        }).ToList();
    }
}