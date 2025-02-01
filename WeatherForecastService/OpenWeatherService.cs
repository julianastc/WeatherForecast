using System.Net.Http.Json;
using Entities;
using Microsoft.Extensions.Configuration;

namespace WeatherForecastService;

public class OpenWeatherService
{
    private readonly IConfiguration _configuration;
    public OpenWeatherService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<OpenWeatherResponse> GetForecast(WeatherRequest weatherRequest)
    {
        var tokenApi = _configuration["OpenWeather:TokenApi"];
        var apiBaseUrl = _configuration["OpenWeather:BaseUrl"];
        var client = new HttpClient();
        var path = $"{apiBaseUrl}?lat={weatherRequest.Latitude}&lon={weatherRequest.Longitude}&date={weatherRequest.Date}&appid={tokenApi}&lang=pt_br&units=metric";
        var response = await client.GetAsync(path);
        var openWeatherResponse = await response.Content.ReadFromJsonAsync<OpenWeatherResponse>();
        return openWeatherResponse;
    }
}
