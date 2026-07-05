using EPOS.Domain.Common;

namespace EPOS.Domain.Entities;

public class Permission : AuditableEntity
{
    public string Module { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}