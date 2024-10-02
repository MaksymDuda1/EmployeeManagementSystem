using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Domain.Helpers;

public class PagedList<T>
{
    public PagedList(List<T> items,int page, int pageSize, int totalCount)
    {
        Items = items;
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
    }
    
    public List<T> Items { get; }

    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public bool HasNextPage => Page * PageSize < TotalCount;
    
    public bool HasPreviousPage => Page > 1;

    public static PagedList<T> Create(List<T> users, int page, int pageSize, int totalCount)
    {
        return new PagedList<T>(users, page, pageSize, totalCount);
    }
}