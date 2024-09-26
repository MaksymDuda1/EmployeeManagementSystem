using EmployeeManagementSystem.Domain.Dtos;
using FluentValidation;

namespace EmployeeManagementSystem.Application.Validations.AuthValidators;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(r => r.UserName).NotNull().NotEmpty()
            .WithMessage("Username is required");
        
        RuleFor(r => r.Email)
            .NotNull().NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address");

        RuleFor(r => r.Password).NotNull().NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long");
    }
}