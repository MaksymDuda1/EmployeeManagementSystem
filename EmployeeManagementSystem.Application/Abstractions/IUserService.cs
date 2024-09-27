using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Helpers;
using FluentResults;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface IUserService
{
    Task<PagedList<UserDto>> GetAllUsers(
        string? name,
        string? role,
        DateOnly? minRegistrationDate,
        DateOnly? maxRegistrationDate,
        bool isLocked,
        int page,
        int pageSize);

    Task<Result<List<User>>> LockUserAsync(Guid id);
    Task<Result<List<User>>> UnlockUserAsync(Guid id);
}