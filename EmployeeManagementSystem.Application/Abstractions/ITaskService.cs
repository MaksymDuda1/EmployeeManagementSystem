using EmployeeManagementSystem.Domain.Dtos;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface ITaskService
{
    Task<List<TaskDto>> GetAllTasksAsync();
    Task<TaskDto> GetTaskByIdAsync(Guid id);
    Task AddTaskAsync(TaskDto taskDto);
    Task UpdateTaskAsync(TaskDto taskDto);
    Task UpsertTaskAsync(TaskDto taskDto);
    Task DeleteTaskAsync(Guid id);
}