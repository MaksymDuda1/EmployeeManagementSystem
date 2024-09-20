using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementSystem.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;
    
    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiration { get; set; }
}