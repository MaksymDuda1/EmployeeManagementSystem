using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using EmployeeManagementSystem.Domain.Dtos.Base;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Domain.Dtos;

public class EmployeeDto : BaseDto<Guid>
{
    public string Position { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public Guid UserId { get; set; }

    [JsonIgnore]
    public virtual ICollection<TaskDto> Tasks { get; set; } = new List<TaskDto>();
    
    [JsonIgnore]
    public virtual ICollection<ProjectDto> Projects { get; set; } = new List<ProjectDto>();

    public virtual UserDto? User { get; set; }
}