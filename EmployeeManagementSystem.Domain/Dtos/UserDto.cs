namespace EmployeeManagementSystem.Domain.Dtos;

public class UserDto
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;
}