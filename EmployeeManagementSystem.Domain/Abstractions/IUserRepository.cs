using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Helpers;

namespace EmployeeManagementSystem.Domain.Abstractions;

public interface IUserRepository
{
    Task<PagedList<User>> GetAllUsersAsync(string? secondName, Guid? roleId, bool? isLocked, DateOnly? registredFrom,
        DateOnly? registredTo, int page = 1, int pageSize = 5);
}