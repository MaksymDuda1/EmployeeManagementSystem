using System.Linq.Expressions;
using Task = System.Threading.Tasks.Task;

namespace EmployeeManagementSystem.Domain.Abstractions;

public interface ITaskRepository
{
    public Task<List<Entities.TaskItem>> GetAllAsync(
        params Expression<Func<Entities.TaskItem, object>>[] includes);

    public Task<List<Entities.TaskItem>> GetByConditionsAsync(
        Expression<Func<Entities.TaskItem, bool>> expression,
        params Expression<Func<Entities.TaskItem, object>>[] includes);

    public Task<Entities.TaskItem?> GetSingleByConditionAsync(
        Expression<Func<Entities.TaskItem, bool>> expression,
        params Expression<Func<Entities.TaskItem, object>>[] includes);

    Task InsertAsync(Entities.TaskItem entity);
    Task InsertRangeAsync(List<Entities.TaskItem> entities);
    Task UpdateAsync(Entities.TaskItem entity);
    Task DeleteAsync(Guid id);
    Task DeleteAsync(Entities.TaskItem entity);
}