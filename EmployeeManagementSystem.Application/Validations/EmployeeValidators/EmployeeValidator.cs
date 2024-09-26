using EmployeeManagementSystem.Domain.Dtos;
using FluentValidation;

namespace EmployeeManagementSystem.Application.Validations.EmployeeValidators;

public class EmployeeValidator : AbstractValidator<EmployeeDto>
{
    public EmployeeValidator()
    {
        RuleFor(e => e.Position).NotEmpty().NotNull()
            .WithMessage("Position cannot be empty");

        RuleFor(e => e.HireDate).NotEmpty().NotNull()
            .WithMessage("Hire Date cannot be empty")
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("Hire Date must be greater than or equal to Today");
    }
}