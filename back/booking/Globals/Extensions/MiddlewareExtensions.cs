using Globals.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Globals.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<CorrelationIdMiddleware>();
        app.UseMiddleware<RequestLoggingMiddleware>();
        app.UseMiddleware<PerformanceMiddleware>();
        app.UseMiddleware<ExceptionMiddleware>();

        return app;
    }
}


//programs
//using Globals.Extensions;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();

//var app = builder.Build();

//app.UseGlobalMiddleware();

//app.MapControllers();

//app.Run();




//в доккере
//        docker compose logs -f booking-service