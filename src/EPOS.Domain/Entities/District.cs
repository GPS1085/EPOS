using EPOS.Domain.Common;

namespace EPOS.Domain.Entities;

public class District : AuditableEntity
{
    public Guid StateId { get; set; }

    public State? State { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}