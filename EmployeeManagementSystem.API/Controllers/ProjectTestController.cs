using AutoMapper;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController]
[Route("api/project")]
public class ProjectTestController(IProjectRepository projectRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var projects = await projectRepository.GetAllAsync();
        return Ok(projects);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProjectDto request)
    {
        await projectRepository.InsertAsync(request);
        
        return Ok(Created());
    }
}