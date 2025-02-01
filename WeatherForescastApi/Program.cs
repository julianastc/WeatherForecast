using Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", async (IConfiguration configuration, string lat, string lon, DateTime date) =>
    {
        var weatherRequest = new WeatherRequest()
        {
            Latitude = lat,
            Longitude = lon,
            Date = date,
        };
        var forecast = new WeatherForecastService.OpenWeatherService(configuration);
        var response = await forecast.GetForecast(weatherRequest);
        return response;
        // receber lat/long data e retorna informacoes relevantes para agora - temperatura sensacao termica chuva
    })
    .WithName("GetWeatherForecast");

app.Run();