using EmployeeManagementSystem.Application.Models;
using EmployeeManagementSystem.Domain.Dtos;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface IAuthorizationService
{
    Task<TokenApiModel> Login(LoginDto loginDto);
    Task<TokenApiModel> Registration(RegistrationDto registrationDto);
    Task Logout();
}