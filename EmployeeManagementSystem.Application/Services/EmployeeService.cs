using AutoMapper;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Errors;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementSystem.Application.Services;

public class EmployeeService(
    IEmployeeRepository employeeRepository,
    UserManager<User> userManager,
    IMapper mapper) : IEmployeeService
{
    public async Task<Result<List<EmployeeDto>>> GetAllEmployeesAsync()
    {
        var employees = await employeeRepository.GetAllAsync(
            e => e.User,
            e => e.Projects,
            e => e.Tasks);

        return Result.Ok(employees.Select(mapper.Map<EmployeeDto>).ToList());
    }

    public async Task<Result<EmployeeDto>> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await employeeRepository.GetSingleByConditionAsync(
            e => e.Id == id,
            e => e.User,
            e => e.Projects,
            e => e.Tasks);

        return employee == null
            ? new EntityNotFoundError("Employee not found")
            : Result.Ok(mapper.Map<EmployeeDto>(employee));
    }

    public async Task<Result> AddEmployeeAsync(EmployeeDto employeeDto)
    {
        var user = await userManager.FindByIdAsync(employeeDto.UserId.ToString());

        if (user == null)
            return new EntityNotFoundError("User not found");

        var existingEmployee = await employeeRepository
            .GetSingleByConditionAsync(e => e.UserId == employeeDto.UserId);

        if (existingEmployee != null)
            return new ValidationError("Current user  already is employee");

        var employee = mapper.Map<Employee>(employeeDto);
        employee.HireDate = DateOnly.FromDateTime(DateTime.Now);

        await employeeRepository.InsertAsync(employee);
        return Result.Ok();
    }

    public async Task<Result> UpdateEmployeeAsync(EmployeeDto employeeDto)
    {
        var employee = await employeeRepository
            .GetSingleByConditionAsync(e => e.Id == employeeDto.Id);

        if (employee == null)
            return new EntityNotFoundError("Employee not found");

        await employeeRepository.UpdateAsync(mapper.Map(employeeDto, employee));

        return Result.Ok();
    }

    public async Task<Result> UpsertEmployeeAsync(EmployeeDto employeeDto)
    {
        var employee = await employeeRepository
            .GetSingleByConditionAsync(e => e.UserId == employeeDto.UserId);

        if (employee == null)
            await AddEmployeeAsync(employeeDto);
        else
            await employeeRepository.UpdateAsync(mapper.Map(employeeDto, employee));

        return Result.Ok();
    }

    public async Task<Result> DeleteEmployeeAsync(Guid id)
    {
        await employeeRepository.DeleteAsync(id);

        return Result.Ok();
    }
}