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
