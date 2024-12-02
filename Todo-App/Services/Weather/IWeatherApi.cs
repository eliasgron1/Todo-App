namespace Todo_App.Services.Weather
{
  public interface IWeatherApi
  {
    Task<string?> GetWeatherDataAsync(Location location);
  }
}
