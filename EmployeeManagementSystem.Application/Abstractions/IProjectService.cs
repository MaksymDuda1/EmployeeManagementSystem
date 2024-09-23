using EmployeeManagementSystem.Domain.Dtos;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface IProjectService
{
    Task<List<ProjectDto>> GetAllProjectsAsync();
    Task<ProjectDto> GetProjectByIdAsync(Guid projectId);
    Task AddProjectAsync(ProjectDto projectDto);
    Task AddManagerToTheProjectAsync(ManagerProjectDto managerProjectDto);
    Task AddEmployeeToTheProjectAsync(ProjectEmployeeDto projectEmployeeDto);
    Task UpdateProjectAsync(ProjectDto projectDto);
    Task UpsertProjectAsync(ProjectDto projectDto);
    Task DeleteProjectAsync(Guid projectId);
}