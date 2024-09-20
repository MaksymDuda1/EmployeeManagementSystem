using EmployeeManagementSystem.Domain.Dtos;

namespace EmployeeManagementSystem.Domain.Abstractions;

public interface ITaskRepository
{
    Task<List<TaskDto>> GetAllAsync();
    Task<TaskDto> GetById(Guid id);
    Task InsertAsync(TaskDto dto);
    Task InsertRangeAsync(List<TaskDto> dtos);
    Task Update(TaskDto dto);
    Task Delete(Guid id);
    Task Delete(TaskDto dto);
}