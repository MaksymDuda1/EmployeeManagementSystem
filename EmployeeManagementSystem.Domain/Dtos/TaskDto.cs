using EmployeeManagementSystem.Domain.Dtos.Base;
using EmployeeManagementSystem.Domain.Enums;

namespace EmployeeManagementSystem.Domain.Dtos;

public class TaskDto : BaseDto<Guid>
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly DeadlineDate { get; set; }

    public int? Status { get; set; }

    public Guid ProjectId { get; set; }

    public Guid EmployeeId { get; set; }

    public EmployeeDto? Employee { get; set; } 

    public ProjectDto? Project { get; set; } 
}