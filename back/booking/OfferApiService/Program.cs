using Globals.Abstractions;
using Globals.EventBus;
using OfferApiService.Service.Interface;
using OfferApiService.Services;
using OfferApiService.Services.Interfaces.RentObj;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IBookedDateService, BookedDateService>();

builder.Services.AddScoped<IParamsCategoryService, ParamsCategoryService>();
builder.Services.AddScoped<IRentObjService, RentObjService>();
builder.Services.AddScoped<IRentObjImageService, RentObjImageService>();
builder.Services.AddScoped<IRentObjParamValueService, RentObjParamValueService>();
builder.Services.AddScoped<IParamItemService, ParamItemService>();


builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddHostedService<OfferRabbitListener>();



//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(8080); // теперь доступно на всех интерфейсах
//});



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
