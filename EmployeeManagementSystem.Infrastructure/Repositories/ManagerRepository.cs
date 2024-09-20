using AutoMapper;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public class ManagerRepository(EmployeeManagementSystemContext context, IMapper mapper)
    : CRudRepository<Manager, ManagerDto, EmployeeManagementSystemContext, Guid>(context, mapper), IManagerRepository
{
    
}