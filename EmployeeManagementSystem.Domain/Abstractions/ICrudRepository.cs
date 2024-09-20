using System.Linq.Expressions;
using EmployeeManagementSystem.Domain.Dtos.Base;

namespace EmployeeManagementSystem.Domain.Abstractions;

public interface ICrudRepository<TDto, TId>
    where TDto : IBaseDto<TId>
    where TId : IEquatable<TId>, IComparable<TId>
{
    public Task<List<TDto>> GetAllAsync();
    public Task<TDto> GetById(Guid id);
    public Task InsertAsync(TDto dto);
    public Task InsertRangeAsync(List<TDto> dtos);
    public Task Update(TDto dto);
    public Task Delete(Guid id);
    public Task Delete(TDto dto);
}
