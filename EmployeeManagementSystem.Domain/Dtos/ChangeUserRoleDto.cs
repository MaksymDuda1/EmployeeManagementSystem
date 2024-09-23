using EmployeeManagementSystem.Domain.Enums;

namespace EmployeeManagementSystem.Domain.Dtos;

public class ChangeUserRoleDto
{
    public Guid UserId { get; set; }

    public UserRole Role { get; set; }
}