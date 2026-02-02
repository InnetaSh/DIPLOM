using Globals.Abstractions;
using Globals.EventBus;
using StatisticApiService.Services;
using StatisticApiService.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IEntityStatsService, EntityStatsService>();

builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
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
