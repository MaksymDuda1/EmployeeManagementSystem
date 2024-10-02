using EmployeeManagementSystem.Domain.Enums;

namespace EmployeeManagementSystem.Domain.Dtos;

public class ChangeUserRoleDto
{
    public Guid UserId { get; set; }

    public EmployeeDto? Employee { get; set; }

    public ManagerDto? Manager { get; set; }

    public string Role { get; set; } = null!;
}