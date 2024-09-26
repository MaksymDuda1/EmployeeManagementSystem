using EmployeeManagementSystem.Application.Models;
using EmployeeManagementSystem.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using IAuthorizationService = EmployeeManagementSystem.Application.Abstractions.IAuthorizationService;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController, Route("api/auth")]
public class AuthorizationController(IAuthorizationService authorizationService)
    : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<TokenApiModel>> Login(LoginDto request)
    {
        var result = await authorizationService.Login(request);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));

        return Ok(result.Value);
    }

    [HttpPost("registration")]
    public async Task<IActionResult> Registration(RegistrationDto request)
    {
        var result = await authorizationService.Registration(request);
        
        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));

        return Ok(result.Value);
    }
}