using EmployeeManagementSystem.Domain.Dtos.Base;

namespace EmployeeManagementSystem.Domain.Dtos;

public class UserDto : BaseDto<Guid>
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public string? Role { get; set; }
        
    public DateOnly? LockoutEnd { get; set; }
    
    public DateOnly RegistrationDate { get; set; }
    
    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;
}