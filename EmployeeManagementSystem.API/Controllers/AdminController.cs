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
        var users = await adminService.GetUsersWithoutRoleAsync();
        return Ok(users);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUsers([FromBody] ChangeUserRoleDto request)
    {
        await adminService.ChangeUserRole(request);
        return Ok();
    }
}