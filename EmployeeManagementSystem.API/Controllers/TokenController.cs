using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController, Route("api/token")]
public class TokenController(ITokenService tokenService) : ControllerBase
{
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(TokenApiModel? tokenModel)
    {
        if (tokenModel is null)
            return BadRequest();

        var refreshedTokenModel = await tokenService.RefreshToken(tokenModel);
        if (refreshedTokenModel.AccessToken is null)
            return BadRequest();

        return Ok(refreshedTokenModel);
    }

    [HttpPost("revoke/{email}")]
    public async Task<IActionResult> Revoke(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return BadRequest();

        var result = await tokenService.RevokeTokenAsync(email);
        if (!result.Succeeded)
            return BadRequest();

        return NoContent();
    }
}