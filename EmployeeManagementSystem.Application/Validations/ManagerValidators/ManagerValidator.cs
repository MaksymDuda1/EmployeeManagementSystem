using System.Data;
using EmployeeManagementSystem.Domain.Dtos;
using FluentValidation;

namespace EmployeeManagementSystem.Application.Validations.ManagerValidators;

public class ManagerValidator : AbstractValidator<ManagerDto>
{
    public ManagerValidator()
    {
        RuleFor(m => m.Department).NotNull().NotEmpty()
            .WithMessage("Department cannot be empty");
        RuleFor(m => m.UserId).NotNull().NotEmpty()
            .WithMessage("UserId cannot be empty");
    }
}