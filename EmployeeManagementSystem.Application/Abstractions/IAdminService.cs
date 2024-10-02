using EmployeeManagementSystem.Domain.Dtos;
using FluentResults;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface IAdminService
{
    Task<Result<StatisticDto>> GetStatistic();

    Task<Result> ChangeUserRole(ChangeUserRoleDto changeUserRoleDto);
}