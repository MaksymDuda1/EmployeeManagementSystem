using AutoMapper;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public class ProjectRepository(EmployeeManagementSystemContext context)
    : CRudRepository<Project, EmployeeManagementSystemContext, Guid>(context), IProjectRepository
{
}