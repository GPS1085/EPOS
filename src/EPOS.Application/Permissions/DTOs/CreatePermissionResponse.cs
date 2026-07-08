namespace EPOS.Application.Permissions.DTOs;

public class CreatePermissionResponse
{
    public bool Success { get; set; }

    public Guid PermissionId { get; set; }

    public string Message { get; set; } = string.Empty;
}