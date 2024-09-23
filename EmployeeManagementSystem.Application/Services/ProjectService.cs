using AutoMapper;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Exceptions;
using Task = System.Threading.Tasks.Task;

namespace EmployeeManagementSystem.Application.Services;

public class ProjectService(
    IProjectRepository projectRepository,
    IManagerRepository managerRepository,
    IEmployeeRepository employeeRepository,
    IMapper mapper) : IProjectService
{
    public async Task<List<ProjectDto>> GetAllProjectsAsync()
    {
        var projects = await projectRepository.GetAllAsync(
            p => p.Tasks,
            p => p.Employees,
            p => p.Managers);

        return projects.Select(mapper.Map<ProjectDto>).ToList();
    }

    public async Task<ProjectDto> GetProjectByIdAsync(Guid projectId)
    {
        var project = await projectRepository
            .GetSingleByConditionAsync(p => p.Id == projectId);

        if (project == null)
            throw new EntityNotFoundException("Project not found");

        return mapper.Map<ProjectDto>(project);
    }

    public async Task AddProjectAsync(ProjectDto projectDto)
    {
        var project = mapper.Map<Project>(projectDto);
        await projectRepository.InsertAsync(project);
    }

    public async Task AddManagerToTheProjectAsync(ManagerProjectDto managerProjectDto)
    {
        var manager = await managerRepository
            .GetSingleByConditionAsync(p => p.Id == managerProjectDto.ManagerId);

        if (manager == null)
            throw new EntityNotFoundException("Manager not found");

        var project = await projectRepository
            .GetSingleByConditionAsync(p => p.Id == managerProjectDto.ProjectId);

        if (project == null)
            throw new EntityNotFoundException("Project not found");

        project.Managers.Add(manager);
        await projectRepository.UpdateAsync(project);
    }

    public async Task AddEmployeeToTheProjectAsync(ProjectEmployeeDto projectEmployeeDto)
    {
        var employee = await employeeRepository
            .GetSingleByConditionAsync(e => e.Id == projectEmployeeDto.EmployeeId);

        if (employee == null)
            throw new EntityNotFoundException("Employee not found");

        var project = await projectRepository
            .GetSingleByConditionAsync(e => e.Id == projectEmployeeDto.ProjectId);

        if (project == null)
            throw new EntityNotFoundException("Project not found");

        project.Employees.Add(employee);
        await projectRepository.UpdateAsync(project);
    }

    public async Task UpdateProjectAsync(ProjectDto projectDto)
    {
        var project = await projectRepository
            .GetSingleByConditionAsync(p => p.Id == projectDto.Id);

        if (project == null)
            throw new Exception("Project not found");

        await projectRepository.UpdateAsync(mapper.Map(projectDto, project));
    }

    public async Task UpsertProjectAsync(ProjectDto projectDto)
    {
        var project = await projectRepository
            .GetSingleByConditionAsync(e => e.Id == projectDto.Id);

        if (project == null)
            await AddProjectAsync(projectDto);
        else
            await projectRepository.UpdateAsync(mapper.Map(projectDto, project));
    }

    public async Task DeleteProjectAsync(Guid projectId)
    {
        await projectRepository.DeleteAsync(projectId);
    }
}