using Globals.Abstractions;
using Globals.EventBus;
using WebApiGateway.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("UserApiService", client =>
{
    //client.BaseAddress = new Uri(builder.Configuration["UserApiServiceUrl"] ?? "http://userapiservice");
    var baseUrl = builder.Configuration["UserApiServiceUrl"] ?? "http://userapiservice";
    var port = builder.Configuration["UserApiServicePort"] ?? "8080";
    client.BaseAddress = new Uri($"{baseUrl}:{port}");
});

builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddHostedService<GetwayRabbitListener>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
