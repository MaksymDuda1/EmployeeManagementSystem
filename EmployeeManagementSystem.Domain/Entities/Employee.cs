using EmployeeManagementSystem.Domain.Entities.Base;

namespace EmployeeManagementSystem.Domain.Entities;

public class Employee : IEntity<Guid>
{
    public Guid Id { get; set; }
    
    public string Position { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public Guid UserId { get; set; }
    
    public virtual ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

    public virtual User User { get; set; } = null!;
    
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
