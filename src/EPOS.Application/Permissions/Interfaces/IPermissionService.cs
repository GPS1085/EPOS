using EPOS.Application.Permissions.DTOs;

namespace EPOS.Application.Permissions.Interfaces;

public interface IPermissionService
{
    Task<CreatePermissionResponse> CreatePermissionAsync(CreatePermissionRequest request);

    Task<List<PermissionResponse>> GetAllPermissionsAsync();
}