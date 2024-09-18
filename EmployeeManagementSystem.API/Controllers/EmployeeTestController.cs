using AutoMapper;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Exceptions;
using EmployeeManagementSystem.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController]
[Route("api/employee")]
public class EmployeeTestController(
    EmployeeManagementSystemContext context,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await context.Employees
            .Include(em => em.User)
            .ToListAsync();
        return Ok(employees.Select(mapper.Map<EmployeeDto>));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddEmployeeDto request)
    {
        var employee = mapper.Map<Employee>(request);

        await context.AddAsync(employee);
        await context.SaveChangesAsync();

        return Ok(Created());
    }
}