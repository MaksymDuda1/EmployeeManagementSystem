using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Infrastructure.Data;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public class TaskRepository(EmployeeManagementSystemContext context)
    : CRudRepository<TaskItem, EmployeeManagementSystemContext, Guid>(context), ITaskRepository
{
}