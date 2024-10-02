using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Helpers;
using FluentResults;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface IUserService
{
    Task<PagedList<UserDto>> GetAllUsers(GetUsersDto usersDto);

    Task<Result<List<UserDto>>> GetUsersWithoutRoleAsync();
    Task<Result<UserDto>> GetUserByIdAsync(Guid id);
    Task<Result<List<User>>> LockUserAsync(Guid id);
    Task<Result<List<User>>> UnlockUserAsync(Guid id);
    Task<Result> DeleteUserAsync(Guid id);
}