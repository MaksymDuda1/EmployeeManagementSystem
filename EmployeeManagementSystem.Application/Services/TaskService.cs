using AutoMapper;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Errors;
using FluentResults;

namespace EmployeeManagementSystem.Application.Services;

public class TaskService(
    ITaskRepository taskRepository,
    IEmployeeRepository employeeRepository,
    IProjectRepository projectRepository,
    IMapper mapper) : ITaskService
{
    public async Task<Result<List<TaskDto>>> GetAllTasksAsync()
    {
        var tasks = await taskRepository.GetAllAsync(
            t => t.Project,
            t => t.Employee);

        return Result.Ok(tasks.Select(mapper.Map<TaskDto>).ToList());
    }

    public async Task<Result<TaskDto>> GetTaskByIdAsync(Guid id)
    {
        var task = await taskRepository.GetSingleByConditionAsync(
            t => t.Id == id,
            t => t.Project,
            t => t.Employee);

        return task == null
            ? new EntityNotFoundError("Entity not found")
            : Result.Ok(mapper.Map<TaskDto>(task));
    }

    public async Task<Result> AddTaskAsync(TaskDto taskDto)
    {
        var employee = await employeeRepository
            .GetSingleByConditionAsync(e => e.Id == taskDto.EmployeeId);

        if (employee == null)
            return new EntityNotFoundError("Employee not found");

        var project = await projectRepository
            .GetSingleByConditionAsync(e => e.Id == taskDto.ProjectId);

        if (project == null)
            return new EntityNotFoundError("Project not found");

        if (taskDto.DeadlineDate > project.EndDate)
            return new ValidationError("Task deadline date cannot be greater than project end date");

        var task = mapper.Map<Domain.Entities.TaskItem>(taskDto);
        await taskRepository.InsertAsync(task);

        return Result.Ok();
    }

    public async Task<Result> UpdateTaskAsync(TaskDto taskDto)
    {
        var task = await taskRepository
            .GetSingleByConditionAsync(e => e.Id == taskDto.Id);

        if (task == null)
            return new EntityNotFoundError("Entity not found");

        var employee = await employeeRepository
            .GetSingleByConditionAsync(e => e.Id == taskDto.EmployeeId);

        if (employee == null)
            return new EntityNotFoundError("Employee not found");

        await taskRepository.UpdateAsync(mapper.Map(taskDto, task));
        return Result.Ok();
    }

    public async Task<Result> UpsertTaskAsync(TaskDto taskDto)
    {
        var task = await taskRepository
            .GetSingleByConditionAsync(e => e.Id == taskDto.Id);

        if (task == null)
            await AddTaskAsync(taskDto);
        else
            await taskRepository.UpdateAsync(mapper.Map(taskDto, task));

        return Result.Ok();
    }

    public async Task<Result> DeleteTaskAsync(Guid id)
    {
        await taskRepository.DeleteAsync(id);
        return Result.Ok();
    }
}