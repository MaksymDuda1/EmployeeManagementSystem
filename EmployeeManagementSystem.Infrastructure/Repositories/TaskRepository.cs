using AutoMapper;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using Task = EmployeeManagementSystem.Domain.Entities.Task;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public class TaskRepository(EmployeeManagementSystemContext context)
    : CRudRepository<Task, EmployeeManagementSystemContext, Guid>(context), ITaskRepository
{
}