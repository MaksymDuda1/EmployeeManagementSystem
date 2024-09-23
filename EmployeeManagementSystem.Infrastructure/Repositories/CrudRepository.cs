using System.Linq.Expressions;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public abstract class CRudRepository<TEntity, TContext, TId>(TContext context)
    : ICRudRepository<TEntity> where TEntity : class, IEntity<TId>
    where TContext : DbContext
    where TId : IEquatable<TId>, IComparable<TId>
{
    public virtual async Task<List<TEntity>> GetAllAsync(
        params Expression<Func<TEntity, object>>[] includes)
    {
        var query = context.Set<TEntity>().AsNoTracking();

        return await includes
            .Aggregate(query, (current, next) => current.Include(next))
            .ToListAsync();
    }

    public virtual async Task<List<TEntity>> GetByConditionsAsync(
        Expression<Func<TEntity, bool>> expression,
        params Expression<Func<TEntity, object>>[] includes)
    {
        var query = context.Set<TEntity>()
            .Where(expression)
            .AsNoTracking();

        return await includes
            .Aggregate(query, (current, next) => current.Include(next))
            .ToListAsync();
    }

    public virtual async Task<TEntity?> GetSingleByConditionAsync(
        Expression<Func<TEntity, bool>> expression,
        params Expression<Func<TEntity, object>>[] includes)
    {
        var result = context.Set<TEntity>()
            .Where(expression)
            .AsNoTracking();

        return await includes
            .Aggregate(result, (current, next) => current.Include(next))
            .FirstOrDefaultAsync();
    }

    public virtual async Task InsertAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task InsertRangeAsync(List<TEntity> entities)
    {
        await context.AddRangeAsync(entities);
        await context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var tEntity = await context.Set<TEntity>().FindAsync(id);

        context.Remove(tEntity);
        await context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
        await context.SaveChangesAsync();
    }
}