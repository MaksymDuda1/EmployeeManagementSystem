using AutoMapper;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<EmployeeDto, Employee>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.HireDate, opt => opt.Ignore());
        CreateMap<Manager, ManagerDto>();
        CreateMap<ManagerDto, Manager>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Project, ProjectDto>().ReverseMap();
        CreateMap<TaskItem, TaskDto>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<RoleDto, Role>().ReverseMap();
        CreateMap<DateTimeOffset, DateOnly>()
            .ConvertUsing(dto => DateOnly.FromDateTime(dto.UtcDateTime));
    }
}