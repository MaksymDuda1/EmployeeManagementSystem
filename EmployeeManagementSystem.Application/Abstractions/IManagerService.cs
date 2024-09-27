using EmployeeManagementSystem.Domain.Dtos;
using FluentResults;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface IManagerService
{
    Task<Result<List<ManagerDto>>> GetAllManagersAsync();
    Task<Result<ManagerDto>> GetManagerByIdAsync(Guid id);
    Task<Result<ManagerDto>> GetManagerByUserIdAsync(Guid userId);
    Task<Result> AddManagerAsync(ManagerDto managerDto);
    Task<Result> UpdateManagerAsync(ManagerDto managerDto);
    Task<Result> UpsertManagerAsync(ManagerDto managerDto);
    Task<Result> DeleteManagerAsync(Guid id);
}