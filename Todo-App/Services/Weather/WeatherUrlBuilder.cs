using System.Globalization;

namespace Todo_App.Services.Weather
{
  public class WeatherUrlBuilder
  {
    private readonly string _baseUrl;
    private readonly string _params;

    public WeatherUrlBuilder()
    {
      _baseUrl = "https://api.open-meteo.com/v1/forecast?";
      _params = "&current=temperature_2m,rain,snowfall,weather_code,wind_speed_10m&daily=weather_code,temperature_2m_max,temperature_2m_min,wind_speed_10m_max&wind_speed_unit=ms&forecast_days=1";
    }
    public string BuildUrl(Location location)
    {
      string formattedLatitude = location.Latitude.ToString(CultureInfo.InvariantCulture);
      string formattedLongitude = location.Longitude.ToString(CultureInfo.InvariantCulture);
      return $"{_baseUrl}latitude={formattedLatitude}&longitude={formattedLongitude}&{_params}";
    }
  }
}
