using Globals.Abstractions;
using Globals.EventBus;
using TranslationApiService.Service.Location;
using TranslationApiService.Service.Location.Interface;
using TranslationApiService.Service.Offer;
using TranslationApiService.Service.Offer.Interface;
using TranslationApiService.Service.Review;
using TranslationApiService.Service.Review.Interface;
using TranslationApiService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


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
