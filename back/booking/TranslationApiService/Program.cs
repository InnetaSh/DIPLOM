using Globals.Abstractions;
using Globals.EventBus;
using Globals.Middleware;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using TranslationApiService.Models;
using TranslationApiService.Service.Attraction;
using TranslationApiService.Service.Attraction.Interface;
using TranslationApiService.Service.Location;
using TranslationApiService.Service.Location.Interface;
using TranslationApiService.Service.Offer;
using TranslationApiService.Service.Offer.Interface;
using TranslationApiService.Service.Review;
using TranslationApiService.Service.Review.Interface;
using TranslationApiService.Services;
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



builder.Services.AddScoped<IAttractionService, AttractionService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IDistrictService, DistrictService>();
builder.Services.AddScoped<IRegionService, RegionService>();

builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IParamsCategoryService, ParamsCategoryService>();
builder.Services.AddScoped<IParamItemService, ParamItemService>();

builder.Services.AddScoped<IReviewService, ReviewService>();


builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddHostedService<TranslationRabbitListener>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TranslationContext>(options =>
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



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter(
                JsonNamingPolicy.CamelCase, 
                allowIntegerValues: true
            )
        );
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; 
    });

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
