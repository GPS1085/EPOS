using EPOS.Domain.Common;

namespace EPOS.Domain.Entities;

public class PasswordHistory : AuditableEntity
{
    public Guid UserId { get; set; }

    public User? User { get; set; }

    public string PasswordHash { get; set; } = string.Empty;

    public DateTime ChangedOn { get; set; }

    public bool IsCurrent { get; set; }
}