using EmployeeManagementSystem.Domain.Entities.Base;

namespace EmployeeManagementSystem.Domain.Entities;

public class Project : IEntity<Guid>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;

    public string Customer { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();
    
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

}
