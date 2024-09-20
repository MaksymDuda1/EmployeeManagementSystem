using EmployeeManagementSystem.Domain.Entities.Base;

namespace EmployeeManagementSystem.Domain.Entities;

public class Manager : IEntity<Guid>
{
    public Guid Id { get; set; }
    
    public string Department { get; set; } = null!;

    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
