using AutoMapper;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = EmployeeManagementSystem.Domain.Entities.Task;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController]
[Route("api/task")]
public class TaskController(
    EmployeeManagementSystemContext context,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tasks = await context.Tasks.ToListAsync();
        return Ok(mapper.Map<List<TaskDto>>(tasks));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddTaskDto request)
    {
        var task = mapper.Map<Task>(request);

        await context.AddAsync(task);
        await context.SaveChangesAsync();
        return Ok(Created());
    }
}