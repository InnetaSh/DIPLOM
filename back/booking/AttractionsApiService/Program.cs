using AttractionsApiService.Service.Interfaces;
using AttractionsApiService.Services;
using AttractionsApiService.Services.Interfaces;
using AttractionsApiService.Services.Interfaces.RentObj;
using Globals.Abstractions;
using Globals.EventBus;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAttractionService, AttractionService>();
builder.Services.AddScoped<IAttractionImageService, AttractionImageService>();

builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddHostedService<AttractionRabbitListener>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
