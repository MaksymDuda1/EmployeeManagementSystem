using AutoMapper;
using EmployeeManagementSystem.Domain.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = EmployeeManagementSystem.Domain.Entities.Task;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController]
[Route("api/task")]
public class TaskController(ITaskRepository taskRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tasks = await taskRepository.GetAllAsync();
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TaskDto request)
    {
        await taskRepository.InsertAsync(request);
        return Ok(Created());
    }
}