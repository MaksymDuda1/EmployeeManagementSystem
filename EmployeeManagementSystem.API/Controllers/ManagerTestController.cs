using AutoMapper;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Exceptions;
using EmployeeManagementSystem.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController]
[Route("api/manager")]
public class ManagerTestController(
    EmployeeManagementSystemContext context,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var manager = await context.Managers
            .Include(manager => manager.User)
            .ToListAsync();
        return Ok(manager.Select(mapper.Map<ManagerDto>));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddManagerDto request)
    {
        var manager = mapper.Map<Manager>(request);
        
        await context.Managers.AddAsync(manager);
        await context.SaveChangesAsync();
        
        return Ok(Created());
    }
}