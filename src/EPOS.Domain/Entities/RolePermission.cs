using EPOS.Domain.Common;

namespace EPOS.Domain.Entities;

public class RolePermission : AuditableEntity
{
    public Guid RoleId { get; set; }

    public Role? Role { get; set; }

    public Guid PermissionId { get; set; }

    public Permission? Permission { get; set; }
}