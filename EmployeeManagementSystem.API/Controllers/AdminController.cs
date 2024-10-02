using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController, Route("api/admin")]
public class AdminController(IAdminService adminService, IFileService fileService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetStatistic()
    {
        var result = await adminService.GetStatistic();

        if (!result.IsSuccess)
            return BadRequest(result.Errors.Select(e => e.Message));

        return Ok(result.Value);
    }

    [HttpPut]
    public async Task<IActionResult> ChangeUserRole([FromBody] ChangeUserRoleDto request)
    {
        var result = await adminService.ChangeUserRole(request);

        if (result.IsFailed)
            return BadRequest(result.Errors.Select(e => e.Message));

        return Ok();
    }

    [HttpPost("export/excel")]
    public async Task<IActionResult> ExportAsExcel([FromBody] ExportDto exportDto)
    {
        var result = await fileService.ExportToExcel(exportDto.Users);

        if (!result.IsSuccess)
            return BadRequest(result.Errors.Select(e => e.Message));

        var file = File(result.Value.ToArray(),
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "exported_data.xlsx");

        return file;
    }

    [HttpPost("export/csv")]
    public async Task<IActionResult> ExportAsCsv([FromBody] ExportDto exportDto)
    {
        var result = await fileService.ExportToCsv(exportDto.Users);

        if (!result.IsSuccess)
            return BadRequest(result.Errors.Select(e => e.Message));

        var file = File(result.Value.ToArray(), "text/csv", "exported_data.csv");
        return file;
    }
}