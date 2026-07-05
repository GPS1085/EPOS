using EPOS.Domain.Common;

namespace EPOS.Domain.Entities;

public class Designation : AuditableEntity
{
    public Guid DepartmentId { get; set; }

    public Department? Department { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public bool IsLeadershipRole { get; set; }

    public bool IsActive { get; set; } = true;
    public ICollection<UserPosting> UserPostings { get; set; }
    = new List<UserPosting>();
}