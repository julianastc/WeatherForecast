namespace Entities;

public record WeatherRequest
{
    public string Latitude { get; set; }
    
    public string Longitude { get; set; }
    
    public DateTime Date { get; set; }
    
}