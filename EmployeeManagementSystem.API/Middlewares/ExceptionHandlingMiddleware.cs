using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.API.Middlewares;

public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            var code = StatusCodes.Status500InternalServerError;
            
            logger.LogError(e, "Exception occurred: {Message}", e.Message);
            var problemDetails = new ProblemDetails()
            {
                Status = code,
                Title = e.Message,
            };

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}