using Globals.Abstractions;
using Globals.EventBus;
using RentObjectApiService.Services;
using RentObjectApiService.Services.Interfaces;
using RentObjectApiService.Services.Interfaces.RentObjectApiService.Services.Interfaces;
using UserApiService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IParamsCategoryService, ParamsCategoryService>();
builder.Services.AddScoped<IRentObjService, RentObjService>();
builder.Services.AddScoped<IRentObjParamsService, RentObjParamsService>();

builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddHostedService<RentObjRabbitListener>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
