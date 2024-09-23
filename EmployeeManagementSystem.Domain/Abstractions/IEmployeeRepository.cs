using System.Linq.Expressions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace EmployeeManagementSystem.Domain.Abstractions;

public interface IEmployeeRepository
{
    public Task<List<Employee>> GetAllAsync(
        params Expression<Func<Employee, object>>[] includes);

    public Task<List<Employee>> GetByConditionsAsync(
        Expression<Func<Employee, bool>> expression,
        params Expression<Func<Employee, object>>[] includes);

    public Task<Employee?> GetSingleByConditionAsync(
        Expression<Func<Employee, bool>> expression,
        params Expression<Func<Employee, object>>[] includes);

    Task InsertAsync(Employee entity);
    Task InsertRangeAsync(List<Employee> entities);
    Task UpdateAsync(Employee entity);
    
    Task DeleteAsync(Guid id);
    Task DeleteAsync(Employee entity);
}