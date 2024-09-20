namespace EmployeeManagementSystem.Domain.Dtos.Base;

public class BaseDto<TId> : IBaseDto<TId>
{
    public TId Id { get; set; }
}