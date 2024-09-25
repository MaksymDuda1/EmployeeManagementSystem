using EmployeeManagementSystem.Domain.Dtos;
using FluentValidation;

namespace EmployeeManagementSystem.Application.Validations.ProjectValidators;

public class ProjectValidator : AbstractValidator<ProjectDto>
{
    public ProjectValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty()
            .WithMessage("Name cannot be empty");
        
        RuleFor(p => p.Customer).NotNull().NotEmpty()
            .WithMessage("Customer cannot be empty");
        
        RuleFor(p => p.StartDate)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("Start date cannot be less than today");
        
        RuleFor(p => p.EndDate).GreaterThanOrEqualTo(p => p.StartDate)
            .WithMessage("End date cannot be less than start date");
    }
}