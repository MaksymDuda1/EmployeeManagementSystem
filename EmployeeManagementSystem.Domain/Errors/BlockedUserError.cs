using FluentResults;

namespace EmployeeManagementSystem.Domain.Errors;

public class BlockedUserError(string message): Error(message)
{
    
}