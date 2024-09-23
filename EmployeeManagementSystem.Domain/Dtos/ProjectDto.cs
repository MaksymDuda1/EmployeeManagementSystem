using System.Text.Json.Serialization;
using EmployeeManagementSystem.Domain.Dtos.Base;

namespace EmployeeManagementSystem.Domain.Dtos;

public class ProjectDto : BaseDto<Guid>
{
    public string Name { get; set; } = null!;

    public string Customer { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    [JsonIgnore]
    public ICollection<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();

    [JsonIgnore]
    public ICollection<ManagerDto> Managers { get; set; } = new List<ManagerDto>();
}