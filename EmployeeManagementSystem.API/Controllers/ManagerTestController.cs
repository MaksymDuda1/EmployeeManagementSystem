using AutoMapper;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController]
[Route("api/manager")]
public class ManagerTestController(IManagerRepository managerRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var manager = await managerRepository.GetAllAsync();
        return Ok(manager);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ManagerDto request)
    {
        await managerRepository.InsertAsync(request);
        return Ok(Created());
    }
}