using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController, Route("api/manager")]
public class ManagerController(IManagerService managerService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllManagers()
    {
        var result = await managerService.GetAllManagersAsync();

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));

        return Ok(result.Value);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetManagerById(Guid id)
    {
        var result = await managerService.GetManagerByIdAsync(id);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));

        return Ok(result.Value);
    }
    
    [HttpGet("by-userId/{userId:guid}")]
    public async Task<IActionResult> GetManagerByUserId(Guid userId)
    {
        var result = await managerService.GetManagerByUserIdAsync(userId);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> AddManager([FromBody] ManagerDto request)
    {
        var result = await managerService.AddManagerAsync(request);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok();
    }

    [HttpPost("upsert")]
    public async Task<IActionResult> UpsertManager([FromBody] ManagerDto request)
    {
        var result = await managerService.UpsertManagerAsync(request);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateManager([FromBody] ManagerDto request)
    {
        var result = await managerService.UpdateManagerAsync(request);
         
        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteManager(Guid id)
    {
        var result = await managerService.DeleteManagerAsync(id);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok();
    }
}