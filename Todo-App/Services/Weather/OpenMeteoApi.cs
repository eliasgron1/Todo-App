using System.Diagnostics;

namespace Todo_App.Services.Weather
{
  public class OpenMeteoApi : IWeatherApi
  {
    private readonly HttpClient _httpClient;
    private readonly WeatherUrlBuilder _weatherUrlBuilder;


    public OpenMeteoApi()
    {
      _httpClient = new HttpClient();
      _weatherUrlBuilder = new WeatherUrlBuilder();
    }

    public async Task<string?> GetWeatherDataAsync(Location location)
    {
      string requestURL = _weatherUrlBuilder.BuildUrl(location);
      try
      {
        Debug.WriteLine($"sending get request to:{requestURL}");
        HttpResponseMessage response = await _httpClient.GetAsync(requestURL);
        response.EnsureSuccessStatusCode();
        Debug.WriteLine($"response: {response.StatusCode}");
        return await response.Content.ReadAsStringAsync();
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"error ocurred when fething weather data: {ex}");
        return null;
      }
    }
  }
}