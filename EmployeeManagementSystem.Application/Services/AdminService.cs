using AutoMapper;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Enums;
using EmployeeManagementSystem.Domain.Errors;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementSystem.Application.Services;

public class AdminService(
    UserManager<User> userManager,
    IMapper mapper) : IAdminService
{
    public async Task<Result<List<UserDto>>> GetUsersWithoutRoleAsync()
    {
        var users = await userManager.GetUsersInRoleAsync(UserRole.Initial.ToString());

        return  Result.Ok( users.Select(mapper.Map<UserDto>).ToList());
    }

    public async Task<Result> ChangeUserRole(ChangeUserRoleDto changeUserRoleDto)
    {
        var user = await userManager.FindByIdAsync(changeUserRoleDto.UserId.ToString());

        if (user == null)
            return new EntityNotFoundError("User not found");

        var roles = await userManager.GetRolesAsync(user);
        await userManager.RemoveFromRoleAsync(user, roles[0]);
        await userManager.AddToRoleAsync(user, changeUserRoleDto.Role.ToString());

        await userManager.UpdateAsync(user);

        return Result.Ok();
    }
}