using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementSystem.Domain.Entities;

public class Role : IdentityRole<Guid>
{
    public static explicit operator string(Role role) => role.Name;
}