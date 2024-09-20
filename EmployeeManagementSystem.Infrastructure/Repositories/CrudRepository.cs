using AutoMapper;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos.Base;
using EmployeeManagementSystem.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public abstract class CRudRepository<TEntity, TDto, TContext, TId>(
    TContext context,
    IMapper mapper)
    : ICrudRepository<TDto, TId>
    where TEntity : class, IEntity<TId>
    where TDto : BaseDto<TId>
    where TContext : DbContext
    where TId : IEquatable<TId>, IComparable<TId>
{
    public virtual async Task<List<TDto>> GetAllAsync()
    {
        var entities = await context.Set<TEntity>()
            .AsNoTracking().ToListAsync();
        
        return entities.Select(mapper.Map<TDto>).ToList();
    }

    public virtual async Task<TDto> GetById(Guid id)
    {
        var entity = await context.Set<TEntity>().FindAsync(id);
        return mapper.Map<TDto>(entity);
    }

    public virtual async Task InsertAsync(TDto dto)
    {
        await context.Set<TEntity>().AddAsync(mapper.Map<TEntity>(dto));
        await context.SaveChangesAsync();
    }

    public virtual async Task InsertRangeAsync(List<TDto> dtos)
    {
        await context.AddRangeAsync(dtos.Select(mapper.Map<TEntity>));
        await context.SaveChangesAsync();
    }

    public virtual async Task Update(TDto dto)
    {
        context.Set<TEntity>().Update(mapper.Map<TEntity>(dto));
        await context.SaveChangesAsync();
    }

    public virtual async Task Delete(Guid id)
    {
        var t = await context.Set<TEntity>().FindAsync(id);

        context.Remove(t);
    }

    public virtual async Task Delete(TDto dto)
    {
        context.Set<TEntity>().Remove(mapper.Map<TEntity>(dto));
        await context.SaveChangesAsync();
    }
}