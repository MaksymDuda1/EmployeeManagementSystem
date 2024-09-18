using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Domain.Entities;

public partial class Employee
{
    public Guid Id { get; set; }

    public string Position { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public Guid UserId { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual AspNetUser User { get; set; } = null!;
}
