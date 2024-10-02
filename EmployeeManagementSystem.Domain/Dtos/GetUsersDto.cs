namespace EmployeeManagementSystem.Domain.Dtos;

public class GetUsersDto
{ 
    public string? SecondName { get; set; }
    public string? Role { get; set; }
    public DateOnly? MinRegistrationDate { get; set; }
    public DateOnly? MaxRegistrationDate { get; set; }
    public bool? IsLocked { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 5;
}