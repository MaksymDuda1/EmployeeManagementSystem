using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController, Route("api/task")]
public class TaskController(ITaskService taskService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var result = await taskService.GetAllTasksAsync();

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok(result.Value);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        var result = await taskService.GetTaskByIdAsync(id);
        
        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> AddTask([FromBody] TaskDto request)
    {
        var result = await taskService.AddTaskAsync(request);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok();
    }

    [HttpPost("upsert")]
    public async Task<IActionResult> UpsertTask([FromBody] TaskDto request)
    {
       var result = await taskService.UpsertTaskAsync(request);

       if (result.IsFailed)
           return BadRequest(result.Errors.Select(e => e.Message));
        
       return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTask([FromBody] TaskDto request)
    {
        var result = await taskService.UpdateTaskAsync(request);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        var result = await taskService.DeleteTaskAsync(id);
        
        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok();
    }
}