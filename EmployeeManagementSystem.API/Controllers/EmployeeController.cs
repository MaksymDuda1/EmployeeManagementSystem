using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController, Route("api/employee")]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var result = await employeeService.GetAllEmployeesAsync();

        if(result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok(result.Value);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetEmployeeById(Guid id)
    {
        var result = await employeeService.GetEmployeeByIdAsync(id);
        
        if(result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto request)
    {
        var result = await employeeService.AddEmployeeAsync(request);
        
        if(result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));

        return Created($"api/employee/{request.Id}", request);
    }
    
    [HttpPost("upsert")]
    public async Task<IActionResult> UpsertEmployee([FromBody] EmployeeDto request)
    {
        var result = await employeeService.UpsertEmployeeAsync(request);

        if(result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto request)
    {
        var result = await employeeService.UpdateEmployeeAsync(request);

        if(result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        var result = await employeeService.DeleteEmployeeAsync(id);
        
        if(result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));
        
        return Ok();
    }
}