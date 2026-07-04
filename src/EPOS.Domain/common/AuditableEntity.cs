namespace EPOS.Domain.Common;

public abstract class AuditableEntity : BaseEntity
{
    public Guid? CreatedByUserId { get; set; }

    public Guid? ModifiedByUserId { get; set; }
}