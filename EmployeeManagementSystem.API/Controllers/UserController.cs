using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController, Route("api/user")]
public class UserController(IUserService userService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsers([FromQuery] GetUsersDto usersDto)
    {
        var result = await userService
            .GetAllUsers(usersDto);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var result = await userService.GetUserByIdAsync(id);
        
        if(!result.IsSuccess)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok(result.Value);
    }

    [HttpGet("without-roles/")]
    public async Task<IActionResult> GetUsersWithoutRoles()
    {
        var result = await userService.GetUsersWithoutRoleAsync();
        
        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e =>e.Message));
        
        return Ok(result.Value);
    }

    [HttpPut("lock/{userId:guid}")]
    public async Task<IActionResult> LockUser(Guid userId)
    {
        var result = await userService.LockUserAsync(userId);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));

        return Ok();
    }

    [HttpPut("unlock/{userId:guid}")]
    public async Task<IActionResult> UnlockUser(Guid userId)
    {
        var result = await userService.UnlockUserAsync(userId);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));

        return Ok();
    }

    [HttpDelete("{userId:guid}")]
    public async Task<IActionResult> DeleteUser(Guid userId)
    {
        var result = await userService.DeleteUserAsync(userId);
        
        if(result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok();
    }
}