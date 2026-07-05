using EPOS.Domain.Common;

namespace EPOS.Domain.Entities;

public class UserPosting : AuditableEntity
{
    public Guid UserId { get; set; }

    public User? User { get; set; }

    public Guid DepartmentId { get; set; }

    public Department? Department { get; set; }

    public Guid DesignationId { get; set; }

    public Designation? Designation { get; set; }

    public Guid? StateId { get; set; }

    public State? State { get; set; }

    public Guid? DistrictId { get; set; }

    public District? District { get; set; }

    public Guid? ConstituencyId { get; set; }

    public Constituency? Constituency { get; set; }

    public Guid? WardId { get; set; }

    public Ward? Ward { get; set; }

    public Guid? BoothId { get; set; }

    public Booth? Booth { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public bool IsPrimaryPosting { get; set; }

    public bool IsActive { get; set; } = true;
}