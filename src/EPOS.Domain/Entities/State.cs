using EPOS.Domain.Common;

namespace EPOS.Domain.Entities;

public class State : AuditableEntity
{
    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}