using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController, Route("api/manager")]
public class ManagerController(IManagerService managerService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllManagers()
    {
        var managers = await managerService.GetAllManagersAsync();

        return Ok(managers);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetManagerById(Guid id)
    {
        var manager = await managerService.GetManagerByIdAsync(id);
        
        return Ok(manager);
    }

    [HttpPost]
    public async Task<IActionResult> AddManager([FromBody] ManagerDto request)
    {
        await managerService.AddManagerAsync(request);

        return Created($"api/project/{request.Id}", request);
    }

    [HttpPost("upsert")]
    public async Task<IActionResult> UpsertManager([FromBody] ManagerDto request)
    {
        await managerService.UpsertManagerAsync(request);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateManager([FromBody] ManagerDto request)
    {
        await managerService.UpdateManagerAsync(request);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteManager(Guid id)
    {
        await managerService.DeleteManagerAsync(id);
        
        return Ok();
    }
}