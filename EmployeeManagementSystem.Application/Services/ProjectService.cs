using AutoMapper;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Errors;
using EmployeeManagementSystem.Domain.Exceptions;
using FluentResults;
using FluentValidation;
using Task = System.Threading.Tasks.Task;

namespace EmployeeManagementSystem.Application.Services;

public class ProjectService(
    IProjectRepository projectRepository,
    IManagerRepository managerRepository,
    IEmployeeRepository employeeRepository,
    IValidator<ProjectDto> projectValidator,
    IMapper mapper) : IProjectService
{
    public async Task<Result<List<ProjectDto>>> GetAllProjectsAsync()
    {
        var projects = await projectRepository.GetAllAsync(
            p => p.Tasks,
            p => p.Employees,
            p => p.Managers);

        return Result.Ok(projects.Select(mapper.Map<ProjectDto>).ToList());
    }

    public async Task<Result<ProjectDto>> GetProjectByIdAsync(Guid projectId)
    {
        var project = await projectRepository
            .GetSingleByConditionAsync(p => p.Id == projectId);

        if (project == null)
            throw new EntityNotFoundException("Project not found");

        return Result.Ok(mapper.Map<ProjectDto>(project));
    }

    public async Task<Result> AddProjectAsync(ProjectDto projectDto)
    {
        var project = mapper.Map<Project>(projectDto);
        await projectRepository.InsertAsync(project);
        
        return Result.Ok();
    }

    public async Task<Result> AddManagerToTheProjectAsync(ManagerProjectDto managerProjectDto)
    {
        var manager = await managerRepository
            .GetSingleByConditionAsync(p => p.Id == managerProjectDto.ManagerId);

        if (manager == null)
            return new EntityNotFoundError("Manager not found");

        var project = await projectRepository
            .GetSingleByConditionAsync(p => p.Id == managerProjectDto.ProjectId);

        if (project == null)
            return new EntityNotFoundError("Project not found");

        project.Managers.Add(manager);
        await projectRepository.UpdateAsync(project);
        
        return Result.Ok();
    }

    public async Task<Result> AddEmployeeToTheProjectAsync(ProjectEmployeeDto projectEmployeeDto)
    {
        var employee = await employeeRepository
            .GetSingleByConditionAsync(e => e.Id == projectEmployeeDto.EmployeeId);

        if (employee == null)
            return new EntityNotFoundError("Employee not found");

        var project = await projectRepository
            .GetSingleByConditionAsync(e => e.Id == projectEmployeeDto.ProjectId);

        if (project == null)
            return new EntityNotFoundError("Project not found");

        project.Employees.Add(employee);
        await projectRepository.UpdateAsync(project);
        
        return Result.Ok();
    }

    public async Task<Result> UpdateProjectAsync(ProjectDto projectDto)
    {
        var project = await projectRepository
            .GetSingleByConditionAsync(p => p.Id == projectDto.Id);

        if (project == null)
            return new EntityNotFoundError("Project not found");

        await projectRepository.UpdateAsync(mapper.Map(projectDto, project));
        return Result.Ok();
    }

    public async Task<Result> UpsertProjectAsync(ProjectDto projectDto)
    {
        var project = await projectRepository
            .GetSingleByConditionAsync(e => e.Id == projectDto.Id);

        if (project == null)
            await AddProjectAsync(projectDto);
        else
            await projectRepository.UpdateAsync(mapper.Map(projectDto, project));
        
        return Result.Ok();
    }

    public async Task<Result> DeleteProjectAsync(Guid projectId)
    {
        await projectRepository.DeleteAsync(projectId);
        return Result.Ok();
    }
}