namespace EmployeeManagementSystem.Domain.Dtos;

public class EmployeeDto
{
    public Guid Id { get; set; }

    public string Position { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public Guid UserId { get; set; }

    public virtual ICollection<TaskDto> Tasks { get; set; } = new List<TaskDto>();

    public virtual UserDto User { get; set; } = null!;
}