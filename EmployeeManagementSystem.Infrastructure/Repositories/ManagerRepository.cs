using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Infrastructure.Data;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public class ManagerRepository(EmployeeManagementSystemContext context)
    : CRudRepository<Manager, EmployeeManagementSystemContext, Guid>(context), IManagerRepository
{
}