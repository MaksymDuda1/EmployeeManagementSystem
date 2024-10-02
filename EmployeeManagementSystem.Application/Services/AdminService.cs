using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Enums;
using EmployeeManagementSystem.Domain.Errors;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Application.Services;

public class AdminService(
    UserManager<User> userManager,
    IManagerService managerService,
    IEmployeeService employeeService) : IAdminService
{
    public async Task<Result<StatisticDto>> GetStatistic()
    {
        var registeredUsers = await userManager.Users.CountAsync();
        var blockedUsers = await userManager.Users.Where(u => u.LockoutEnd != null).CountAsync();

        var response = new StatisticDto()
        {
            UsersAmount = registeredUsers,
            BlockedUsersAmount = blockedUsers,
        };

        return Result.Ok(response);
    }

    public async Task<Result> ChangeUserRole(ChangeUserRoleDto changeUserRoleDto)
    {
        var role = changeUserRoleDto.Role;
        var user = await userManager.FindByIdAsync(changeUserRoleDto.UserId.ToString());

        if (user == null)
            return new EntityNotFoundError("User not found");

        var roles = await userManager.GetRolesAsync(user);
        await userManager.RemoveFromRolesAsync(user, roles);
        await userManager.AddToRoleAsync(user, role.ToString());

        if (role == UserRole.Manager.ToString())
        {
            if (changeUserRoleDto.Manager == null)
                return new ValidationError("Manager data cannot be null");

            changeUserRoleDto.Manager.UserId = user.Id;

            await managerService.UpsertManagerAsync(changeUserRoleDto.Manager);
        }

        if (role == UserRole.Employee.ToString())
        {
            if (changeUserRoleDto.Employee == null)
                return new ValidationError("Employee data cannot be null");

            changeUserRoleDto.Employee.UserId = user.Id;

            await employeeService.UpsertEmployeeAsync(changeUserRoleDto.Employee);
        }

        await userManager.UpdateAsync(user);

        return Result.Ok();
    }
}