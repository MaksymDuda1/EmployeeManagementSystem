using System;
using System.Collections.Generic;
using EmployeeManagementSystem.Infrastructure;

namespace EmployeeManagementSystem.Domain.Entities;

public partial class Task
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly DeadlineDate { get; set; }

    public int? Status { get; set; }

    public Guid ProjectId { get; set; }

    public Guid EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
