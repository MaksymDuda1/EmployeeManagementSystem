using EmployeeManagementSystem.API;
using EmployeeManagementSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmployeeManagementSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeManagementSystemContext")));

var app = builder.ConfigureService().ConfigurePipeline();

await app.RunAsync();