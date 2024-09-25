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
        var employees = await employeeService.GetAllEmployeesAsync();

        return Ok(employees);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetEmployeeById(Guid id)
    {
        var employee = await employeeService.GetEmployeeByIdAsync(id);
        
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto request)
    {
        await employeeService.AddEmployeeAsync(request);

        return Created($"api/employee/{request.Id}", request);
    }
    
    [HttpPost("upsert")]
    public async Task<IActionResult> UpsertEmployee([FromBody] EmployeeDto request)
    {
        await employeeService.UpsertEmployeeAsync(request);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto request)
    {
        await employeeService.UpdateEmployeeAsync(request);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        await employeeService.DeleteEmployeeAsync(id);
        
        return Ok();
    }
}