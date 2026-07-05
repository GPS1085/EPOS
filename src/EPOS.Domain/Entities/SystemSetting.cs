using EPOS.Domain.Common;

namespace EPOS.Domain.Entities;

public class SystemSetting : AuditableEntity
{
    public string Category { get; set; } = string.Empty;

    public string Key { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsEditable { get; set; } = true;

    public bool IsActive { get; set; } = true;
}