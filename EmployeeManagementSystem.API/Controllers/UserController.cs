using EmployeeManagementSystem.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController, Route("api/user")]
public class UserController(IUserService userService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsers(
        [FromQuery] string? name,
        string? role,
        DateOnly? minRegistrationDate,
        DateOnly? maxRegistrationDate,
        bool isLocked = false,
        int page = 1,
        int pageSize = 10)
    {
        var result = await userService
            .GetAllUsers(name, role, minRegistrationDate, maxRegistrationDate, isLocked, page, pageSize);

        return Ok(result);
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
}