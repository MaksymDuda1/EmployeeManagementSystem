namespace EmployeeManagementSystem.Domain.Dtos;

public class UpdateProjectDto
{
    public string Name { get; set; } = null!;

    public string Customer { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
}