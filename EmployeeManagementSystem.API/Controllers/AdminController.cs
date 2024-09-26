using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController, Route("api/admin")]
public class AdminController(IAdminService adminService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUsersWithoutRoles()
    {
        var result = await adminService.GetUsersWithoutRoleAsync();
        
        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e =>e.Message));
        
        return Ok(result.Value);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUsers([FromBody] ChangeUserRoleDto request)
    {
        var result = await adminService.ChangeUserRole(request);
        
        if(result.IsFailed)
            return BadRequest(result.Errors.Select(e =>e.Message));
        
        return Ok();
    }
}