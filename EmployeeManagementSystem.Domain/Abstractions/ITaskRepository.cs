using System.Linq.Expressions;
using EmployeeManagementSystem.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace EmployeeManagementSystem.Domain.Abstractions;

public interface ITaskRepository
{
    public Task<List<Entities.Task>> GetAllAsync(
        params Expression<Func<Entities.Task, object>>[] includes);

    public Task<List<Entities.Task>> GetByConditionsAsync(
        Expression<Func<Entities.Task, bool>> expression,
        params Expression<Func<Entities.Task, object>>[] includes);

    public Task<Entities.Task?> GetSingleByConditionAsync(
        Expression<Func<Entities.Task, bool>> expression,
        params Expression<Func<Entities.Task, object>>[] includes);

    Task InsertAsync(Entities.Task entity);
    Task InsertRangeAsync(List<Entities.Task> entities);
    Task UpdateAsync(Entities.Task entity);
    Task DeleteAsync(Guid id);
    Task DeleteAsync(Entities.Task entity);
}