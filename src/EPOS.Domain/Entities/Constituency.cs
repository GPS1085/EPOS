using EPOS.Domain.Common;

namespace EPOS.Domain.Entities;

public class Constituency : AuditableEntity
{
    public Guid DistrictId { get; set; }

    public District? District { get; set; }

    public string Name { get; set; } = string.Empty;

    public int ConstituencyNumber { get; set; }

    public bool IsActive { get; set; } = true;
}