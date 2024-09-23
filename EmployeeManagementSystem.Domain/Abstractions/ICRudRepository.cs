using System.Linq.Expressions;

namespace EmployeeManagementSystem.Domain.Abstractions;

public interface ICRudRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync(
        params Expression<Func<TEntity, object>>[] includes);

    Task<List<TEntity>> GetByConditionsAsync(
        Expression<Func<TEntity, bool>> expression,
        params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity?> GetSingleByConditionAsync(
        Expression<Func<TEntity, bool>> expression,
        params Expression<Func<TEntity, object>>[] includes);

    Task InsertAsync(TEntity entity);
    Task InsertRangeAsync(List<TEntity> entities);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid id);
    Task DeleteAsync(TEntity entity);
}