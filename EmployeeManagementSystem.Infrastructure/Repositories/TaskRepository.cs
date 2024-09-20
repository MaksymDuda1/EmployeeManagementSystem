using AutoMapper;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using Task = EmployeeManagementSystem.Domain.Entities.Task;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public class TaskRepository(EmployeeManagementSystemContext context, IMapper mapper)
    : CRudRepository<Task, TaskDto, EmployeeManagementSystemContext, Guid>(context, mapper), ITaskRepository
{
}