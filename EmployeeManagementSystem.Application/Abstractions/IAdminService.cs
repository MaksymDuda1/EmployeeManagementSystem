using EmployeeManagementSystem.Domain.Dtos;
using FluentResults;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface IAdminService
{
    Task<Result<List<UserDto>>> GetUsersWithoutRoleAsync();
    Task<Result> ChangeUserRole(ChangeUserRoleDto changeUserRoleDto);
}