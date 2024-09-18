using System;
using System.Collections.Generic;
using EmployeeManagementSystem.Infrastructure;

namespace EmployeeManagementSystem.Domain.Entities;

public partial class Manager
{
    public Guid Id { get; set; }

    public string Department { get; set; } = null!;

    public Guid UserId { get; set; }

    public virtual AspNetUser User { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
