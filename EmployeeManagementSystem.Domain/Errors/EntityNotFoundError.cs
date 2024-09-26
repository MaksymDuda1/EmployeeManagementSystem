using FluentResults;

namespace EmployeeManagementSystem.Domain.Errors;

public class EntityNotFoundError(string message) : Error(message)
{
    
}