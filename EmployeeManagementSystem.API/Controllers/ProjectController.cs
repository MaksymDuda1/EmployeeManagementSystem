using AutoMapper;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController, Route("api/project")]
public class ProjectController(IProjectService projectService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var projects = await projectService.GetAllProjectsAsync();

        return Ok(projects);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProjectById(Guid id)
    {
        var project = await projectService.GetProjectByIdAsync(id);
        
        return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> AddProject([FromBody] ProjectDto request)
    {
        await projectService.AddProjectAsync(request);

        return Created($"api/project/{request.Id}", request);
    }
    

    [HttpPost("upsert")]
    public async Task<IActionResult> UpsertProject([FromBody] ProjectDto request)
    {
        await projectService.UpsertProjectAsync(request);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProject([FromBody] ProjectDto request)
    {
        await projectService.UpdateProjectAsync(request);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProject(Guid id)
    {
        await projectService.DeleteProjectAsync(id);
        
        return Ok();
    }
}