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
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("Deadline date cannot be less than today");
        
        RuleFor(t => t.Status).LessThan(5)
            .WithMessage("Wrong status");
    }
}