namespace EmployeeManagementSystem.Domain.Dtos;

public class AddEmployeeDto
{
       public string Position { get; set; } = null!;
   
       public DateOnly HireDate { get; set; }
   
       public Guid UserId { get; set; }
}