using EmployeeManagementSystem.Domain.Enums;

namespace EmployeeManagementSystem.Domain.Dtos;

public class UpdateTaskDto
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly DeadlineDate { get; set; }

    public int? Status { get; set; }
}