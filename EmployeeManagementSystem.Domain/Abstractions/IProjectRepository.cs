using System.Linq.Expressions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace EmployeeManagementSystem.Domain.Abstractions;

public interface IProjectRepository
{
    public Task<List<Project>> GetAllAsync(
        params Expression<Func<Project, object>>[] includes);

    public Task<List<Project>> GetByConditionsAsync(
        Expression<Func<Project, bool>> expression,
        params Expression<Func<Project, object>>[] includes);

    public Task<Project?> GetSingleByConditionAsync(
        Expression<Func<Project, bool>> expression,
        params Expression<Func<Project, object>>[] includes);

    Task InsertAsync(Project entity);
    Task InsertRangeAsync(List<Project> entities);
    Task UpdateAsync(Project entity);
    Task DeleteAsync(Guid id);
    Task DeleteAsync(Project entity);
}