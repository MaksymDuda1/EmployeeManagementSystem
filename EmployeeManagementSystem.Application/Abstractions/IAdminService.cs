using EmployeeManagementSystem.Domain.Dtos;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface IAdminService
{
    Task<List<UserDto>> GetUsersWithoutRoleAsync();
    Task ChangeUserRole(ChangeUserRoleDto changeUserRoleDto);
}