using EmployeeManagementSystem.Application.Models;
using EmployeeManagementSystem.Domain.Dtos;
using FluentResults;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface IAuthorizationService
{
    Task<Result<TokenApiModel>> Login(LoginDto loginDto);
    Task<Result<TokenApiModel>> Registration(RegistrationDto registrationDto); 
}