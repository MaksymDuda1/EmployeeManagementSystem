using AutoMapper;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public class ManagerRepository(EmployeeManagementSystemContext context)
    : CRudRepository<Manager, EmployeeManagementSystemContext, Guid>(context), IManagerRepository
{
}