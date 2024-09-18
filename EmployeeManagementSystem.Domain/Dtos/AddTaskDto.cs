namespace EmployeeManagementSystem.Domain.Dtos;

public class AddTaskDto
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly DeadlineDate { get; set; }

    public int? Status { get; set; }

    public Guid ProjectId { get; set; }

    public Guid EmployeeId { get; set; }
}