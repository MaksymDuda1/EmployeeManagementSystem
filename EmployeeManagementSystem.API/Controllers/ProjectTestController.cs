using AutoMapper;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController]
[Route("api/project")]
public class ProjectTestController(
    EmployeeManagementSystemContext context,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var projects = await context.Projects.ToListAsync(); 
        return Ok(projects.Select(mapper.Map<ProjectDto>));
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddProjectDto request)
    {
        var project = mapper.Map<Project>(request);
        await context.Projects.AddAsync(project);
        await context.SaveChangesAsync();
        
        return Ok(Created());
    }
}