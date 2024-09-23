using AutoMapper;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Task = System.Threading.Tasks.Task;

namespace EmployeeManagementSystem.Application.Services;

public class ManagerService(
    IManagerRepository managerRepository,
    UserManager<User> userManager,
    IMapper mapper) : IManagerService
{
    public async Task<List<ManagerDto>> GetAllManagersAsync()
    {
        var managers = await managerRepository.GetAllAsync(
            m => m.User,
            m => m.Projects);

        return managers.Select(mapper.Map<ManagerDto>).ToList();
    }

    public async Task<ManagerDto> GetManagerByIdAsync(Guid id)
    {
        var manager = await managerRepository.GetSingleByConditionAsync(
            m => m.Id == id,
            e => e.User,
            m => m.Projects);

        if (manager == null)
            throw new EntityNotFoundException("Manager not found");

        return mapper.Map<ManagerDto>(manager);
    }

    public async Task AddManagerAsync(ManagerDto managerDto)
    {
        var user = await userManager.FindByIdAsync(managerDto.UserId.ToString());

        if (user == null)
            throw new EntityNotFoundException("User not found");

        var manager = mapper.Map<Manager>(managerDto);
        await managerRepository.InsertAsync(manager);
    }

    public async Task UpdateManagerAsync(ManagerDto managerDto)
    {
        var manager = await managerRepository
            .GetSingleByConditionAsync(m => m.Id == managerDto.Id);

        if (manager == null)
            throw new EntityNotFoundException("Manager not found");


        await managerRepository.UpdateAsync(mapper.Map(managerDto, manager));
    }

    public async Task UpsertManagerAsync(ManagerDto managerDto)
    {
        var manager = await managerRepository
            .GetSingleByConditionAsync(m => m.Id == managerDto.Id);

        if (manager == null)
            await AddManagerAsync(managerDto);
        else
            await managerRepository.UpdateAsync(mapper.Map(managerDto, manager));
    }

    public async Task DeleteManagerAsync(Guid id)
    {
        await managerRepository.DeleteAsync(id);
    }
}