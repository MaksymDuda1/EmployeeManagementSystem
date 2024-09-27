using AutoMapper;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Errors;
using EmployeeManagementSystem.Domain.Helpers;
using FluentResults;
using Microsoft.AspNetCore.Identity;


namespace EmployeeManagementSystem.Application.Services;

public class UserService(
    UserManager<User> userManager,
    IMapper mapper) : IUserService
{
    public async Task<PagedList<UserDto>> GetAllUsers(
        string? name,
        string? role,
        DateOnly? minRegistrationDate,
        DateOnly? maxRegistrationDate,
        bool isLocked,
        int page,
        int pageSize)
    {
        var usersQuery = !string.IsNullOrEmpty(role)
            ? (await userManager.GetUsersInRoleAsync(role)).AsQueryable()
            : userManager.Users.AsQueryable();

        if (!string.IsNullOrEmpty(name))
            usersQuery = usersQuery.Where(u =>
                u.SecondName.Contains(name));

        if (minRegistrationDate.HasValue)
            usersQuery = usersQuery.Where(u =>
                u.RegistrationDate >= minRegistrationDate);

        if (maxRegistrationDate.HasValue)
            usersQuery = usersQuery.Where(u =>
                u.RegistrationDate <= maxRegistrationDate);

        if (isLocked)
            usersQuery = usersQuery.Where(u => u.LockoutEnd != null);

        var usersQueryResponse = usersQuery.Select(e => mapper.Map<UserDto>(e));
        
        var users = await PagedList<UserDto>.CreateAsync(
            usersQueryResponse, page, pageSize);

        return users;
    }

    public async Task<Result<List<User>>> LockUserAsync(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());

        if (user == null) return new EntityNotFoundError("User not found");

        user.LockoutEnd = DateTime.UtcNow.AddYears(100);
        var result = await userManager.UpdateAsync(user);

        return !result.Succeeded
            ? Result.Fail(result.Errors.Select(e => e.Description))
            : Result.Ok();
    }

    public async Task<Result<List<User>>> UnlockUserAsync(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());

        if (user == null) return new EntityNotFoundError("User not found");

        user.LockoutEnd = null;
        await userManager.UpdateAsync(user);

        return Result.Ok();
    }
}