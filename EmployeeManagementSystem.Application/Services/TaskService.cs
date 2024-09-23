using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Exceptions;

namespace EmployeeManagementSystem.Application.Services;

public class TaskService(
    ITaskRepository taskRepository,
    IEmployeeRepository employeeRepository,
    IProjectRepository projectRepository,
    IMapper mapper) : ITaskService
{
    public async Task<List<TaskDto>> GetAllTasksAsync()
    {
        var tasks = await taskRepository.GetAllAsync(
            t => t.Project,
            t => t.Employee);

        return tasks.Select(mapper.Map<TaskDto>).ToList();
    }

    public async Task<TaskDto> GetTaskByIdAsync(Guid id)
    {
        var task = await taskRepository.GetSingleByConditionAsync(
            t => t.Id == id,
            t => t.Project,
            t => t.Employee);

        if (task == null)
            throw new EntityNotFoundException("Entity not found");

        return mapper.Map<TaskDto>(task);
    }

    public async Task AddTaskAsync(TaskDto taskDto)
    {
        var employee = await employeeRepository
            .GetSingleByConditionAsync(e => e.Id == taskDto.EmployeeId);
        
        if(employee == null)
            throw new EntityNotFoundException("Employee not found");
        
        var project = await projectRepository
            .GetSingleByConditionAsync(e => e.Id == taskDto.ProjectId);
        
        if(project == null)
            throw new EntityNotFoundException("Project not found");
        
        if(taskDto.DeadlineDate > project.EndDate)
            throw new ValidationException("Task deadline date cannot be greater than project end date");

        var task = mapper.Map<Domain.Entities.Task>(taskDto);
        await taskRepository.InsertAsync(task);
    }

    public async Task UpdateTaskAsync(TaskDto taskDto)
    {
        var task = await taskRepository
            .GetSingleByConditionAsync(e => e.Id == taskDto.Id);

        if (task == null)
            throw new EntityNotFoundException("Entity not found");
        
        var employee = await employeeRepository
            .GetSingleByConditionAsync(e => e.Id == taskDto.EmployeeId);
        
        if(employee == null)
            throw new EntityNotFoundException("Employee not found");

        await taskRepository.UpdateAsync(mapper.Map(taskDto, task));
    }

    public async Task UpsertTaskAsync(TaskDto taskDto)
    {
        var task = await taskRepository
            .GetSingleByConditionAsync(e => e.Id == taskDto.Id);

        if (task == null)
            await AddTaskAsync(taskDto);
        else
            await taskRepository.UpdateAsync(mapper.Map(taskDto, task));
    }

    public async Task DeleteTaskAsync(Guid id)
    {
        await taskRepository.DeleteAsync(id);
    }
}