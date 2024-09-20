using EmployeeManagementSystem.Domain.Dtos.Base;

namespace EmployeeManagementSystem.Domain.Dtos;

public class UserDto : BaseDto<Guid>
{
    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;
}