namespace EmployeeManagementSystem.Domain.Dtos.Base;

public interface IBaseDto<TId>
{
    public TId Id { get; set; }
}