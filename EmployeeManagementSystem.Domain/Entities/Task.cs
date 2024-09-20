using System;
using System.Collections.Generic;
using EmployeeManagementSystem.Domain.Entities.Base;

namespace EmployeeManagementSystem.Domain.Entities;

public class Task : IEntity<Guid>
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