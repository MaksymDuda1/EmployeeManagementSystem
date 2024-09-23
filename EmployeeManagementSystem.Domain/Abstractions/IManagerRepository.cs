using System.Linq.Expressions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace EmployeeManagementSystem.Domain.Abstractions;

public interface IManagerRepository
{
    public Task<List<Manager>> GetAllAsync(
        params Expression<Func<Manager, object>>[] includes);

    public Task<List<Manager>> GetByConditionsAsync(
        Expression<Func<Manager, bool>> expression,
        params Expression<Func<Manager, object>>[] includes);

    public Task<Manager?> GetSingleByConditionAsync(
        Expression<Func<Manager, bool>> expression,
        params Expression<Func<Manager, object>>[] includes);

    Task InsertAsync(Manager entity);
    Task InsertRangeAsync(List<Manager> entities);
    Task UpdateAsync(Manager entity);
    
    Task DeleteAsync(Guid id);
    Task DeleteAsync(Manager entity);
}