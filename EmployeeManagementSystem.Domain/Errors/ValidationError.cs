using FluentResults;

namespace EmployeeManagementSystem.Domain.Errors;

public class ValidationError(string message) : Error(message)
{
    
}