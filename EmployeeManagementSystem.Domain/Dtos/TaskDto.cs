using EmployeeManagementSystem.Domain.Enums;

namespace EmployeeManagementSystem.Domain.Dtos;

public class TaskDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly DeadlineDate { get; set; }

    public int? Status { get; set; }

    public Guid ProjectId { get; set; }

    public Guid EmployeeId { get; set; }

    public virtual EmployeeDto Employee { get; set; } = null!;

    public virtual ProjectDto Project { get; set; } = null!;
}