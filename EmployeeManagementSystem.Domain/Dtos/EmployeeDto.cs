using System.Reflection.Metadata.Ecma335;
using EmployeeManagementSystem.Domain.Dtos.Base;

namespace EmployeeManagementSystem.Domain.Dtos;

public class EmployeeDto : BaseDto<Guid>
{
    public string Position { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public Guid UserId { get; set; }

    public virtual ICollection<TaskDto> Tasks { get; set; } = new List<TaskDto>();

    public virtual UserDto? User { get; set; } = null!;
}