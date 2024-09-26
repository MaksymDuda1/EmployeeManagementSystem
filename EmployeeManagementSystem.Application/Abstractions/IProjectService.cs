using EmployeeManagementSystem.Domain.Dtos;
using FluentResults;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface IProjectService
{
    Task<Result<List<ProjectDto>>> GetAllProjectsAsync();
    Task<Result<ProjectDto>> GetProjectByIdAsync(Guid projectId);
    Task<Result> AddProjectAsync(ProjectDto projectDto);
    Task<Result> AddManagerToTheProjectAsync(ManagerProjectDto managerProjectDto);
    Task<Result> AddEmployeeToTheProjectAsync(ProjectEmployeeDto projectEmployeeDto);
    Task<Result> UpdateProjectAsync(ProjectDto projectDto);
    Task<Result> UpsertProjectAsync(ProjectDto projectDto);
    Task<Result> DeleteProjectAsync(Guid projectId);
}