using EmployeeManagementSystem.Domain.Entities;
using Task = EmployeeManagementSystem.Domain.Entities.Task;

namespace EmployeeManagementSystem.Infrastructure;

public partial class Project
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Customer { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();
}
