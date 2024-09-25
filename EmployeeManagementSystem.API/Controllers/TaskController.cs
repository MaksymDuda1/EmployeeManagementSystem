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
        var tasks = await taskService.GetAllTasksAsync();

        return Ok(tasks);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        var task = await taskService.GetTaskByIdAsync(id);
        
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> AddTask([FromBody] TaskDto request)
    {
        await taskService.AddTaskAsync(request);

        return Created($"api/task/{request.Id}", request);
    }

    [HttpPost("upsert")]
    public async Task<IActionResult> UpsertTask([FromBody] TaskDto request)
    {
        await taskService.UpsertTaskAsync(request);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTask([FromBody] TaskDto request)
    {
        await taskService.UpdateTaskAsync(request);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        await taskService.DeleteTaskAsync(id);
        
        return Ok();
    }
}