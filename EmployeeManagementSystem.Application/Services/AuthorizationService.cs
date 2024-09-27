using System.Security.Authentication;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Application.Models;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Enums;
using EmployeeManagementSystem.Domain.Errors;
using EmployeeManagementSystem.Domain.Exceptions;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementSystem.Application.Services;

public class AuthorizationService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    ITokenService tokenService) : IAuthorizationService
{
    public async Task<Result<TokenApiModel>> Login(LoginDto loginDto)
    {
        var userByUsername = await userManager.FindByNameAsync(loginDto.UserName);
        
        if (userByUsername == null) 
            return new EntityNotFoundError("No user with given username was found");

        var userByEmail = await userManager.FindByEmailAsync(loginDto.Email);

        if (userByEmail == null)
            return new EntityNotFoundError("No user with given email was found");

        var result = await signInManager
            .PasswordSignInAsync(userByEmail.UserName, loginDto.Password, false, false);

        return !result.Succeeded
            ? new ValidationError("Wrong password")
            : Result.Ok(await tokenService.GenerateToken(userByEmail, true));
    }

    public async Task<Result<TokenApiModel>> Registration(RegistrationDto registrationDto)
    {
        var user = new User()
        {
            Email = registrationDto.Email,
            FirstName = registrationDto.FirstName,
            SecondName = registrationDto.SecondName,
            UserName = registrationDto.UserName,
        };

        var result = await userManager.CreateAsync(user, registrationDto.Password);

        if (!result.Succeeded)
            return new ValidationError(result.Errors.First().Description);

        await userManager.AddToRoleAsync(user, UserRole.Initial.ToString());
        await userManager.UpdateAsync(user);

        return Result.Ok(await tokenService.GenerateToken(user, true));
    }
}