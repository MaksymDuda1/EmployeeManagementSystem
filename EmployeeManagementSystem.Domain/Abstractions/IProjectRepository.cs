using EmployeeManagementSystem.Domain.Dtos;

namespace EmployeeManagementSystem.Domain.Abstractions;

public interface IProjectRepository
{
    Task<List<ProjectDto>> GetAllAsync();
    Task<ProjectDto> GetById(Guid id);
    Task InsertAsync(ProjectDto dto);
    Task InsertRangeAsync(List<ProjectDto> dtos);
    Task Update(ProjectDto dto);
    Task Delete(Guid id);
    Task Delete(ProjectDto dto);
}