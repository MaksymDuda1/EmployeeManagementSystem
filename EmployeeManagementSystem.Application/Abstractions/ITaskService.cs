using EmployeeManagementSystem.Domain.Dtos;
using FluentResults;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface ITaskService
{
    Task<Result<List<TaskDto>>> GetAllTasksAsync();
    Task<Result<TaskDto>> GetTaskByIdAsync(Guid id);
    Task<Result> AddTaskAsync(TaskDto taskDto);
    Task<Result> UpdateTaskAsync(TaskDto taskDto);
    Task<Result> UpsertTaskAsync(TaskDto taskDto);
    Task<Result> DeleteTaskAsync(Guid id);
}