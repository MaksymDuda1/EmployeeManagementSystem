using EmployeeManagementSystem.Domain.Dtos;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface IManagerService
{
    Task<List<ManagerDto>> GetAllManagersAsync();
    Task<ManagerDto> GetManagerByIdAsync(Guid id);
    Task AddManagerAsync(ManagerDto managerDto);
    Task UpdateManagerAsync(ManagerDto managerDto);
    Task UpsertManagerAsync(ManagerDto managerDto);
    Task DeleteManagerAsync(Guid id);
}