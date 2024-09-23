using EmployeeManagementSystem.Domain.Dtos;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetAllEmployeesAsync();
    Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
    Task AddEmployeeAsync(EmployeeDto employeeDto);
    Task UpdateEmployeeAsync(EmployeeDto employeeDto);
    Task UpsertEmployeeAsync(EmployeeDto employeeDto);
    Task DeleteEmployeeAsync(Guid id);
}