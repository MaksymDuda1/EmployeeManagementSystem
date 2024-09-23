using System.Security.Authentication;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Application.Models;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Enums;
using EmployeeManagementSystem.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Task = System.Threading.Tasks.Task;

namespace EmployeeManagementSystem.Application.Services;

public class AuthorizationService (
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    ITokenService tokenService) : IAuthorizationService
{
    public async Task<TokenApiModel> Login(LoginDto loginDto)
    {
        var userByEmail = await userManager.FindByEmailAsync(loginDto.Email);

        if (userByEmail == null)
            throw new EntityNotFoundException("No user with given email was found");

        var result = await signInManager
            .PasswordSignInAsync(userByEmail.UserName, loginDto.Password, false, false);

        if (!result.Succeeded)
            throw new CredentialValidationException("Wrong password");

        return await tokenService.GenerateToken(userByEmail, true);
    }

    public async Task<TokenApiModel> Registration(RegistrationDto registrationDto)
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
            throw new AuthenticationException(result.Errors.First().Description);

        await userManager.AddToRoleAsync(user, UserRole.Initial.ToString());
        await userManager.UpdateAsync(user);

        return await tokenService.GenerateToken(user);
    }
}