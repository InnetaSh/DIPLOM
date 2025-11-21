using Globals.Abstractions;
using Globals.EventBus;
using OfferApiService.Service;
using OfferApiService.Service.Interface;
using OfferApiService.Services;
using OfferApiService.Services.Interfaces.RentObject;
using OfferApiService.Services.RentObject;
using UserApiService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IBookedDateService, BookedDateService>();

builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IParamsCategoryService, ParamsCategoryService>();
builder.Services.AddScoped<IRentObjService, RentObjService>();
builder.Services.AddScoped<IRentObjImageService, RentObjImageService>();
builder.Services.AddScoped<IRentObjParamValueService, RentObjParamValueService>();
builder.Services.AddScoped<IParamItemService, ParamItemService>();


builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddHostedService<OfferRabbitListener>();

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
