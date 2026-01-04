using Globals.Abstractions;
using Globals.EventBus;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApiGateway.Services;
using WebApiGetway.Controllers;
using WebApiGetway.Service;
using WebApiGetway.Service.Interfase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()  
            .AllowAnyMethod()  
            .AllowAnyHeader();  
    });
});


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("UserApiService", client =>
{
    var baseUrl = builder.Configuration["UserApiServiceUrl"] ?? "http://userapiservice";
    var port = builder.Configuration["UserApiServicePort"] ?? "8080";
    client.BaseAddress = new Uri($"{baseUrl}:{port}");
});

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Bearer {your JWT token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
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


builder.Services.AddHttpClient("LocationApiService", client =>
{
    var baseUrl = builder.Configuration["LocationApiServiceUrl"] ?? "http://locationapiservice";
    var port = builder.Configuration["LocationApiServicePort"] ?? "8080";
    client.BaseAddress = new Uri($"{baseUrl}:{port}");
});


builder.Services.AddHttpClient("OrderApiService", client =>
{
    var baseUrl = builder.Configuration["OrderApiServiceUrl"] ?? "http://orderapiservice";
    var port = builder.Configuration["OrderApiServicePort"] ?? "8080";
    client.BaseAddress = new Uri($"{baseUrl}:{port}");
});

builder.Services.AddHttpClient("ReviewApiService", client =>
{
    var baseUrl = builder.Configuration["ReviewApiServiceUrl"] ?? "http://reviewapiservice";
    var port = builder.Configuration["ReviewApiServicePort"] ?? "8080";
    client.BaseAddress = new Uri($"{baseUrl}:{port}");
});


builder.Services.AddHttpClient("AttractionApiService", client =>
{
    var baseUrl = builder.Configuration["AttractionApiService"] ?? "http://attractionapiservice";
    var port = builder.Configuration["AttractionApiServicePort"] ?? "8080";
    client.BaseAddress = new Uri($"{baseUrl}:{port}");
});

builder.Services.AddHttpClient("TranslationApiService", client =>
{
    var baseUrl = builder.Configuration["TranslationApiServiceUrl"] ?? "http://translationapiservice";
    var port = builder.Configuration["TranslationApiServicePort"] ?? "8080";
    client.BaseAddress = new Uri($"{baseUrl}:{port}");
});



//builder.Services.AddHttpClient<IOfferServiceClient, OfferServiceClient>(client =>
//{
//    var baseUrl = "http://offerapiservice";
//    var port = "8080";
//    client.BaseAddress = new Uri($"{baseUrl}:{port}");
//});

builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddHostedService<GetwayRabbitListener>();

builder.Services.AddScoped<IGatewayService, GatewayService>();
builder.Services.AddMemoryCache(); 

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            )
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
