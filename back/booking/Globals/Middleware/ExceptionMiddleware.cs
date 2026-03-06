using Globals.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Globals.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly bool _showDetails;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IConfiguration config)
        {
            _next = next;
            _logger = logger;
            _showDetails = config.GetValue<bool>("ShowExceptionDetails");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            int status;
            string title;

            switch (exception)
            {
                case ValidationException:
                    status = (int)HttpStatusCode.BadRequest;
                    title = "Validation error";
                    break;
                case NotFoundException:
                    status = (int)HttpStatusCode.NotFound;
                    title = "Resource not found";
                    break;
                case UnauthorizedAccessException:
                    status = (int)HttpStatusCode.Unauthorized;
                    title = "Unauthorized";
                    break;
                case ForbiddenException:
                    status = (int)HttpStatusCode.Forbidden;
                    title = "Forbidden";
                    break;
                default:
                    status = (int)HttpStatusCode.InternalServerError;
                    title = "Server error";
                    break;
            }

            var problem = new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = _showDetails ? exception.Message : "An unexpected error occurred",
                Instance = context.Request.Path
            };

            context.Response.Headers.Add("X-Trace-Id", context.TraceIdentifier);
            context.Response.StatusCode = status;

            var json = JsonSerializer.Serialize(problem);
            return context.Response.WriteAsync(json);
        }
    }
}