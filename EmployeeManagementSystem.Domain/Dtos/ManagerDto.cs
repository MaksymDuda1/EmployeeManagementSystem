
namespace EmployeeManagementSystem.Domain.Dtos;

public class ManagerDto
{
    public Guid Id { get; set; }

    public string Department { get; set; } = null!;

    public Guid UserId { get; set; }

    public virtual UserDto User { get; set; } = null!;

    public virtual ICollection<ProjectDto> Projects { get; set; } = new List<ProjectDto>();
}