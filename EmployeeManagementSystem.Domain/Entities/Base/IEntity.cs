
namespace EmployeeManagementSystem.Domain.Entities.Base;

public interface IEntity<TId> where TId : IEquatable<TId>, IComparable<TId>
{
    public TId Id { get; set; }
}