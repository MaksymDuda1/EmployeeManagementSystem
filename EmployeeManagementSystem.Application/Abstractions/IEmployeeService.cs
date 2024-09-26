using EmployeeManagementSystem.Domain.Dtos;
using FluentResults;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface IEmployeeService
{
    Task<Result<List<EmployeeDto>>> GetAllEmployeesAsync();
    Task<Result<EmployeeDto>> GetEmployeeByIdAsync(Guid id);
    Task<Result> AddEmployeeAsync(EmployeeDto employeeDto);
    Task<Result> UpdateEmployeeAsync(EmployeeDto employeeDto);
    Task<Result> UpsertEmployeeAsync(EmployeeDto employeeDto);
    Task<Result> DeleteEmployeeAsync(Guid id);
}