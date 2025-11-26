using Globals.Abstractions;
using Globals.EventBus;
using WebApiGateway.Services;
using WebApiGetway.Controllers;
using WebApiGetway.Service;
using WebApiGetway.Service.Interfase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("UserApiService", client =>
{
    var baseUrl = builder.Configuration["UserApiServiceUrl"] ?? "http://userapiservice";
    var port = builder.Configuration["UserApiServicePort"] ?? "8080";
    client.BaseAddress = new Uri($"{baseUrl}:{port}");
});

//builder.Services.AddHttpClient<IUserServiceClient, UserServiceClient>(client =>
//{
//    var baseUrl = "http://userapiservice";
//    var port = "8080";
//    client.BaseAddress = new Uri($"{baseUrl}:{port}");
//});

builder.Services.AddHttpClient("OfferApiService", client =>
{
    var baseUrl = builder.Configuration["OfferApiServiceUrl"] ?? "http://offerapiservice";
    var port = builder.Configuration["OfferApiServicePort"] ?? "8080";
    client.BaseAddress = new Uri($"{baseUrl}:{port}");
});


builder.Services.AddHttpClient<IOfferServiceClient, OfferServiceClient>(client =>
{
    var baseUrl = "http://offerapiservice";
    var port = "8080";
    client.BaseAddress = new Uri($"{baseUrl}:{port}");
});

builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddHostedService<GetwayRabbitListener>();

builder.Services.AddScoped<IGatewayService, GatewayService>();
builder.Services.AddScoped<IServiceBase<TestModel>, TestService>();


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
