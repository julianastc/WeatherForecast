using System.Text.Json.Serialization;

namespace Entities;

public record WeatherResponse()
{
    public string Temperature { get; set; }
    
    public string FeelsLike { get; set; }
    
    public string Precipitation { get; set; }
}