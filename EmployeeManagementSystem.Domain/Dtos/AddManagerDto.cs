namespace EmployeeManagementSystem.Domain.Dtos;

public class AddManagerDto
{
    public string Department { get; set; } = null!;

    public Guid UserId { get; set; }
}