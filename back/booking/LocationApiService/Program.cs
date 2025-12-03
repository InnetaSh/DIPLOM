using Globals.Abstractions;
using Globals.EventBus;
using LocationApiService.Service.Interfaces;
using LocationApiService.Services;
using LocationApiService.Services;
using OfferApiService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAttractionService, AttractionService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IDistrictService, DistrictService>();
builder.Services.AddScoped<IRegionService, RegionService>();


builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddHostedService<LocationRabbitListener>();

var app = builder.Build();

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
app.UseAuthorization();

app.MapControllers();

app.Run();
