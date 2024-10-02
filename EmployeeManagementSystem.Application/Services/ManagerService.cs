using AutoMapper;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Errors;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementSystem.Application.Services;

public class ManagerService(
    IManagerRepository managerRepository,
    UserManager<User> userManager,
    IMapper mapper) : IManagerService
{
    public async Task<Result<List<ManagerDto>>> GetAllManagersAsync()
    {
        var managers = await managerRepository.GetAllAsync(
            m => m.User,
            m => m.Projects);

        return Result.Ok(managers.Select(mapper.Map<ManagerDto>).ToList());
    }

    public async Task<Result<ManagerDto>> GetManagerByIdAsync(Guid id)
    {
        var manager = await managerRepository.GetSingleByConditionAsync(
            m => m.Id == id,
            m => m.User,
            m => m.Projects);

        return manager == null
            ? new EntityNotFoundError("Manager not found")
            : Result.Ok(mapper.Map<ManagerDto>(manager));
    }

    public async Task<Result<ManagerDto>> GetManagerByUserIdAsync(Guid userId)
    {
        var manager = await managerRepository.GetSingleByConditionAsync(
            m => m.UserId == userId,
            m => m.User,
            m => m.Projects);

        return manager == null
            ? new EntityNotFoundError("Manager not found")
            : Result.Ok(mapper.Map<ManagerDto>(manager));
    }

    public async Task<Result> AddManagerAsync(ManagerDto managerDto)
    {
        var user = await userManager.FindByIdAsync(managerDto.UserId.ToString());

        if (user == null)
            return new EntityNotFoundError("User not found");

        var existingManager = await managerRepository
            .GetSingleByConditionAsync(m => m.UserId == user.Id);

        if (existingManager != null)
            return new ValidationError("Current user already is manager");

        var manager = mapper.Map<Manager>(managerDto);
        await managerRepository.InsertAsync(manager);

        return Result.Ok();
    }

    public async Task<Result> UpdateManagerAsync(ManagerDto managerDto)
    {
        var manager = await managerRepository
            .GetSingleByConditionAsync(m => m.Id == managerDto.Id);

        if (manager == null)
            return new EntityNotFoundError("Manager not found");

        
        await managerRepository.UpdateAsync(mapper.Map<Manager>(managerDto));
        return Result.Ok();
    }

    public async Task<Result> UpsertManagerAsync(ManagerDto managerDto)
    {
        var manager = await managerRepository
            .GetSingleByConditionAsync(m => m.UserId == managerDto.UserId);

        if (manager == null)
            await AddManagerAsync(managerDto);
        else
            await managerRepository.UpdateAsync(manager);

        return Result.Ok();
    }

    public async Task<Result> DeleteManagerAsync(Guid id)
    {
        await managerRepository.DeleteAsync(id);
        return Result.Ok();
    }
}