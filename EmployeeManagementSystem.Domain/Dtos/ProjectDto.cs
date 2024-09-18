namespace EmployeeManagementSystem.Domain.Dtos;

public class ProjectDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Customer { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public ICollection<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();

    public ICollection<ManagerDto> Managers { get; set; } = new List<ManagerDto>();
}