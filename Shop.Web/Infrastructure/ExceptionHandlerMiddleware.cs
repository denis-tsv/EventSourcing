using System.Net;
using Shop.Web.UseCases.Exceptions;

namespace Shop.Web.Infrastructure;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (EntityNotFoundException notFound)
        {
            await HandleException(httpContext, notFound.Message, HttpStatusCode.NotFound);
        }
    }

    private async Task HandleException(HttpContext httpContext, string message, HttpStatusCode code)
    {
        httpContext.Response.StatusCode = (int)code;

        await httpContext.Response.WriteAsync(message);
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}