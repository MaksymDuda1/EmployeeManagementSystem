using AutoMapper;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public class EmployeeRepository(EmployeeManagementSystemContext context, IMapper mapper)
    : CRudRepository<Employee, EmployeeDto, EmployeeManagementSystemContext, Guid>(context, mapper), IEmployeeRepository
{
}