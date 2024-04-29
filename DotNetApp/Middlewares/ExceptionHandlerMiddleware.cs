using System.Net;
using DotNetApp.Core;
using DotNetApp.Core.Exceptions;
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
        switch (exception)
        {
            case UnauthorizedException:
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                var response = new Response<object>
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Unauthorized",
                    Detailed = exception.Message
                };

                var result = JsonConvert.SerializeObject(response);
                return context.Response.WriteAsync(result);
            }
            case NotFoundException:
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;

                var response = new Response<object>
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Not Found",
                    Detailed = exception.Message
                };

                var result = JsonConvert.SerializeObject(response);
                return context.Response.WriteAsync(result);
            }
            case BadRequestException:
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var response = new Response<object>
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Bad Request",
                    Detailed = exception.Message
                };

                var result = JsonConvert.SerializeObject(response);
                return context.Response.WriteAsync(result);
            }
            case ForbiddenException:
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;

                var response = new Response<object>
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Forbidden",
                    Detailed = exception.Message
                };

                var result = JsonConvert.SerializeObject(response);
                return context.Response.WriteAsync(result);
            }
            case UnprocessableEntityException:
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;

                var response = new Response<object>
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Unprocessable Entity",
                    Detailed = exception.Message
                };

                var result = JsonConvert.SerializeObject(response);
                return context.Response.WriteAsync(result);
            }
            default:
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new Response<object>
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error",
                    Detailed = exception.Message
                };

                var result = JsonConvert.SerializeObject(response);

                return context.Response.WriteAsync(result);
            }
        }
    }
}