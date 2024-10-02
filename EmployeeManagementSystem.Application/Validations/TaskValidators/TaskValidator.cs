using EmployeeManagementSystem.Domain.Dtos;
using FluentValidation;

namespace EmployeeManagementSystem.Application.Validations.TaskValidators;

public class TaskValidator : AbstractValidator<TaskDto>
{
    public TaskValidator()
    {
        RuleFor(t => t.Name).NotNull().NotEmpty()
            .WithMessage("Name cannot be empty");

        RuleFor(t => t.DeadlineDate)
            .NotEmpty().WithMessage("Deadline date cannot be empty")
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("Deadline date cannot be less than today");
        
        RuleFor(t => t.Status)
            .NotEmpty().WithMessage("Status cannot be empty")
            .LessThan(5).WithMessage("Wrong status");
        
        RuleFor(t => t.ProjectId).NotEmpty().NotNull()
            .WithMessage("Project cannot be empty");
        
        RuleFor(t => t.EmployeeId).NotNull().NotEmpty()
            .WithMessage("Employee cannot be empty");
    }
}