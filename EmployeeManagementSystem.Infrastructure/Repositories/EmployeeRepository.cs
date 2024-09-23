using AutoMapper;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public class EmployeeRepository(EmployeeManagementSystemContext context)
    : CRudRepository<Employee, EmployeeManagementSystemContext, Guid>(context), IEmployeeRepository
{
}