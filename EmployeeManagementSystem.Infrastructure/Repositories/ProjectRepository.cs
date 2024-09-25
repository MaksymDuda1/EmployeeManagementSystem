using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Infrastructure.Data;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public class ProjectRepository(EmployeeManagementSystemContext context)
    : CRudRepository<Project, EmployeeManagementSystemContext, Guid>(context), IProjectRepository
{
}