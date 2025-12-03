using Globals.Abstractions;
using Globals.EventBus;
using ReviewApiService.Service.Interface;
using ReviewApiService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IReviewService, ReviewService>();


builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddHostedService<ReviewRabbitListener>();

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
