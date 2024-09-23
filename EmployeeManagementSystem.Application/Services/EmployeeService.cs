using AutoMapper;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Task = System.Threading.Tasks.Task;

namespace EmployeeManagementSystem.Application.Services;

public class EmployeeService(
    IEmployeeRepository employeeRepository,
    UserManager<User> userManager,
    IMapper mapper) : IEmployeeService
{
    public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
    {
        var employees = await employeeRepository.GetAllAsync(
            e => e.User,
            e => e.Projects,
            e => e.Tasks);

        return employees.Select(mapper.Map<EmployeeDto>).ToList();
    }

    public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await employeeRepository.GetSingleByConditionAsync(
            e => e.Id == id,
            e => e.User,
            e => e.Projects,
            e => e.Tasks);

        if (employee == null)
            throw new EntityNotFoundException("Employee not found");

        return mapper.Map<EmployeeDto>(employee);
    }

    public async Task AddEmployeeAsync(EmployeeDto employeeDto)
    {
        var user = await userManager.FindByIdAsync(employeeDto.UserId.ToString());

        if (user == null)
            throw new EntityNotFoundException("User not found");

        var employee = mapper.Map<Employee>(employeeDto);
        await employeeRepository.InsertAsync(employee);
    }

    public async Task UpdateEmployeeAsync(EmployeeDto employeeDto)
    {
        var employee = await employeeRepository
            .GetSingleByConditionAsync(e => e.Id == employeeDto.Id);

        if (employee == null)
            throw new EntityNotFoundException("Employee not found");

        await employeeRepository.UpdateAsync(mapper.Map(employeeDto, employee));
    }

    public async Task UpsertEmployeeAsync(EmployeeDto employeeDto)
    {
        var employee = await employeeRepository
            .GetSingleByConditionAsync(e => e.Id == employeeDto.Id);

        if (employee == null)
            await AddEmployeeAsync(employeeDto);
        else
            await employeeRepository.UpdateAsync(mapper.Map(employeeDto, employee));
    }

    public async Task DeleteEmployeeAsync(Guid id)
    {
        await employeeRepository.DeleteAsync(id);
    }
}