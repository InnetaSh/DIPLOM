using Globals.Abstractions;
using Globals.EventBus;
using Globals.Extensions;
using Globals.Middleware;
using Microsoft.EntityFrameworkCore;
using ReviewApiService.Service;
using ReviewApiService.Models;
using ReviewApiService.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ReviewContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"));

    var enableSensitive =
        Environment.GetEnvironmentVariable("ENABLE_SENSITIVE_LOGGING");

    var aspEnv =
        Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    if (string.Equals(enableSensitive, "true", StringComparison.OrdinalIgnoreCase)
        || string.Equals(aspEnv, "Development", StringComparison.OrdinalIgnoreCase))
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    }
});

builder.Services.AddScoped<IReviewService, ReviewService>();


builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddHostedService<ReviewRabbitListener>();

var app = builder.Build();
//app.UseMiddleware<ExceptionMiddleware>();
app.UseGlobalMiddleware();


Console.WriteLine($"Environment: {app.Environment.EnvironmentName}");

if (app.Environment.IsDevelopment())
{
    Console.WriteLine("Swagger enabled");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    Console.WriteLine("Swagger disabled");
}

app.UseStaticFiles();

app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
