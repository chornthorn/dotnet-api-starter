using System.Net;
using Newtonsoft.Json;

namespace DotNetApp.Middlewares;

public class ExceptionHandlerMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // check type of exception
        if (exception is UnauthorizedAccessException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            var response = new
            {
                status = context.Response.StatusCode,
                message = "Unauthorized",
                detailed = exception.Message
            };

            var result = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(result);
        }

        if (exception is BadHttpRequestException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var response = new
            {
                status = context.Response.StatusCode,
                message = "Bad Request",
                detailed = exception.Message
            };

            var result = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(result);
        }

        else
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                status = context.Response.StatusCode,
                message = "Internal Server Error",
                detailed = exception.Message,
            };

            var result = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(result);
        }
    }
}