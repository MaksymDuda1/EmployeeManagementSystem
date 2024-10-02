using EmployeeManagementSystem.Domain.Dtos;
using FluentResults;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface IFileService
{
    Task<Result<MemoryStream>> ExportToExcel(List<UserDto> users);
    Task<Result<MemoryStream>> ExportToCsv(List<UserDto> users);
}