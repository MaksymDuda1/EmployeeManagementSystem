using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController, Route("api/project")]
public class ProjectController(IProjectService projectService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var result = await projectService.GetAllProjectsAsync();

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));

        return Ok(result.Value);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProjectById(Guid id)
    {
        var result = await projectService.GetProjectByIdAsync(id);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> AddProject([FromBody] ProjectDto request)
    {
        var result = await projectService.AddProjectAsync(request);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));

        return Ok();
    }


    [HttpPost("upsert")]
    public async Task<IActionResult> UpsertProject([FromBody] ProjectDto request)
    {
        var result = await projectService.UpsertProjectAsync(request);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProject([FromBody] ProjectDto request)
    {
        var result = await projectService.UpdateProjectAsync(request);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProject(Guid id)
    {
        var result = await projectService.DeleteProjectAsync(id);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok();
    }
}