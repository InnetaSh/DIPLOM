using Globals.Abstractions;
using Globals.EventBus;
using Globals.Middleware;
using Microsoft.EntityFrameworkCore;
using OrderApiService.Service.Interface;
using OrderApiService.Services;
using OrderApiService.Models;
using Globals.Extensions;

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

builder.Services.AddDbContext<OrderContext>(options =>
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


builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddHostedService<OrderRabbitListener>();

var app = builder.Build();
//app.UseMiddleware<ExceptionMiddleware>();
app.UseGlobalMiddleware();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
