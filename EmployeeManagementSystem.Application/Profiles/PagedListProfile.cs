using AutoMapper;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Helpers;

namespace EmployeeManagementSystem.Application.Profiles;

public class PagedListProfile(IMapper mapper) : ITypeConverter<PagedList<User>, PagedList<UserDto>>
{
    public PagedList<UserDto> Convert(PagedList<User> source, PagedList<UserDto> destination, ResolutionContext context)
    {
        var userDtos = mapper.Map<List<UserDto>>(source.Items);

        return new PagedList<UserDto>(userDtos, source.Page, source.PageSize, source.TotalCount);
    }
}