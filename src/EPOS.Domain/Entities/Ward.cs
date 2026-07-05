using EPOS.Domain.Common;
using EPOS.Domain.Enums;

namespace EPOS.Domain.Entities;

public class Ward : AuditableEntity
{
    public Guid ConstituencyId { get; set; }

    public Constituency? Constituency { get; set; }

    public string WardName { get; set; } = string.Empty;

    public int WardNumber { get; set; }

    public WardType WardType { get; set; }

    public bool IsActive { get; set; } = true;
}