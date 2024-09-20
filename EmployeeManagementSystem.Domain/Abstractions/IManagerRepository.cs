using EmployeeManagementSystem.Domain.Dtos;

namespace EmployeeManagementSystem.Domain.Abstractions;

public interface IManagerRepository
{
    Task<List<ManagerDto>> GetAllAsync();
    Task<ManagerDto> GetById(Guid id);
    Task InsertAsync(ManagerDto dto);
    Task InsertRangeAsync(List<ManagerDto> dtos);
    Task Update(ManagerDto dto);
    Task Delete(Guid id);
    Task Delete(ManagerDto dto);
}