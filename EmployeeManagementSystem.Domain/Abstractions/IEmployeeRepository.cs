using EmployeeManagementSystem.Domain.Dtos;

namespace EmployeeManagementSystem.Domain.Abstractions;

public interface IEmployeeRepository
{
    Task<List<EmployeeDto>> GetAllAsync();
    Task<EmployeeDto> GetById(Guid id);
    Task InsertAsync(EmployeeDto dto);
    Task InsertRangeAsync(List<EmployeeDto> dtos);
    Task Update(EmployeeDto dto);
    Task Delete(Guid id);
    Task Delete(EmployeeDto dto);
}