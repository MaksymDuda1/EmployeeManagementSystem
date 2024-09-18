using AutoMapper;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Infrastructure;
using Task = EmployeeManagementSystem.Domain.Entities.Task;

namespace EmployeeManagementSystem.Application.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Employee, AddEmployeeDto>().ReverseMap();
        CreateMap<Manager, ManagerDto>().ReverseMap();
        CreateMap<AddManagerDto, Manager>();
        CreateMap<Project, ProjectDto>().ReverseMap();
        CreateMap<Project, AddProjectDto>().ReverseMap();
        CreateMap<Task, TaskDto>().ReverseMap();
        CreateMap<Task, AddTaskDto>().ReverseMap();
        CreateMap<UserDto, AspNetUser>().ReverseMap();
    }
}