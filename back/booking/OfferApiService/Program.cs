using Globals.Abstractions;
using Globals.EventBus;
using Globals.Extensions;
using Globals.Middleware;
using Microsoft.EntityFrameworkCore;
using OfferApiService.Models;
using OfferApiService.Service;
using OfferApiService.Service.Interface;
using OfferApiService.Services;
using OfferApiService.Services.Interfaces.RentObj;
using System.Text.Json.Serialization;

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

builder.Services.AddDbContext<OfferContext>(options =>
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


builder.Services.AddScoped<IOfferService, OfferService>();

builder.Services.AddScoped<IParamsCategoryService, ParamsCategoryService>();
builder.Services.AddScoped<IRentObjService, RentObjService>();
builder.Services.AddScoped<IRentObjImageService, RentObjImageService>();
builder.Services.AddScoped<IRentObjParamValueService, RentObjParamValueService>();
builder.Services.AddScoped<IParamItemService, ParamItemService>();

builder.Services.AddHttpClient<GeocodingService>();


builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddHostedService<OfferRabbitListener>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });
builder.Services.AddControllers()
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(8080); // теперь доступно на всех интерфейсах
//});



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
