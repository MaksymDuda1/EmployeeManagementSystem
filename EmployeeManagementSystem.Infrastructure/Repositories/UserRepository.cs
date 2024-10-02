using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Helpers;
using EmployeeManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public class UserRepository(EmployeeManagementSystemContext context) : IUserRepository
{
    public async Task<PagedList<User>> GetAllUsersAsync(
        string? secondName,
        Guid? roleId,
        bool? isLocked,
        DateOnly? registeredFrom,
        DateOnly? registeredTo,
        int page = 1, int pageSize = 5)
    {
        var users = await context.Users.FromSqlRaw(
            "EXEC [dbo].[Get_USERS_LIST] @SECOND_NAME = {0}, @ROLE_ID = {1}, @IS_LOCKED = {2}," +
            " @REGISTRED_FROM = {3}, @REGISTRED_TO = {4}, @PAGE = {5}, @PAGE_SIZE = {6}",
            secondName, roleId, isLocked, registeredFrom, registeredTo, page, pageSize).ToListAsync();
        
        var totalCount = context.Users.Count();
        
        return PagedList<User>.Create(users, page, pageSize, totalCount);
    }
}