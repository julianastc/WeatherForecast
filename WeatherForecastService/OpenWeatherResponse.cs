using System.Text.Json.Serialization;

namespace WeatherForecastService;

public record OpenWeatherResponse
{
    [JsonPropertyName("current")]
    public Current Current { get; set; }
    [JsonPropertyName("minutely")]
    public List<Minutely> MinutelyPrecipitations { get; set; }
}

public record Current
{
    [JsonPropertyName("temp")]
    public decimal Temperature { get; set; }
    [JsonPropertyName("feels_like")]
    public decimal FeelsLike { get; set; }
    [JsonPropertyName("weather")]
    public List<Weather> Weather { get; set; }
}

public record Minutely
{
    [JsonPropertyName("precipitation")]
    public decimal Precipitation { get; set; }
}

public record Weather
{
    [JsonPropertyName("description")]
    public string Description { get; set; }
}

