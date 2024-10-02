using AutoMapper;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Enums;
using EmployeeManagementSystem.Domain.Errors;
using EmployeeManagementSystem.Domain.Helpers;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementSystem.Application.Services;

public class UserService(
    UserManager<User> userManager,
    RoleManager<Role> roleManager,
    IUserRepository userRepository,
    IMapper mapper) : IUserService
{
    public async Task<PagedList<UserDto>> GetAllUsers(GetUsersDto usersDto)
    {
        Guid? roleId = null;
        if(usersDto.Role != null)
            roleId = (await roleManager.FindByNameAsync(usersDto.Role))?.Id;
        
        var pagedUsers = await userRepository.GetAllUsersAsync(
            usersDto.SecondName,
            roleId,
            usersDto.IsLocked,
            usersDto.MinRegistrationDate,
            usersDto.MaxRegistrationDate,
            usersDto.Page,
            usersDto.PageSize);
        
        return mapper.Map<PagedList<UserDto>>(pagedUsers) ;
    }

    public async Task<Result<List<UserDto>>> GetUsersWithoutRoleAsync()
    {
        var users = await userManager.GetUsersInRoleAsync(UserRole.Initial.ToString());

        return Result.Ok(users.Select(mapper.Map<UserDto>).ToList());
    }

    public async Task<Result<UserDto>> GetUserByIdAsync(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());

        if (user == null)
            return new EntityNotFoundError("User Not Found");

        var userDto = mapper.Map<UserDto>(user);
        var roles = await userManager.GetRolesAsync(user);
        userDto.Role = roles[0];

        return Result.Ok(userDto);
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

    public async Task<Result> DeleteUserAsync(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());

        if (user == null) return new EntityNotFoundError("User not found");

        await userManager.DeleteAsync(user);
        return Result.Ok();
    }
}