using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Infrastructure.Data;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public class EmployeeRepository(EmployeeManagementSystemContext context)
    : CRudRepository<Employee, EmployeeManagementSystemContext, Guid>(context), IEmployeeRepository
{
}