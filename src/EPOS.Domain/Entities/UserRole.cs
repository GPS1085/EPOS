using EPOS.Domain.Common;

namespace EPOS.Domain.Entities;

public class UserRole : AuditableEntity
{
    public Guid UserId { get; set; }

    public User? User { get; set; }

    public Guid RoleId { get; set; }

    public Role? Role { get; set; }
}