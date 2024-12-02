using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Todo_App.Services.GeoLocation;
using Todo_App.Services.Weather;
using Todo_App.Util;


namespace Todo_App.ViewModels
{
  public class WeatherViewModel : INotifyPropertyChanged
  {
    private string? _highestTemp;
    private string? _lowestTemp;
    private string? _maxWind;
    private string? _currentTemperature;
    private string? _currentWindSpeed;
    private Location? _currentLocation;
    private Color? _maxWindTextColor;

    private readonly IWeatherApi _weatherApi;
    private readonly IParser _parser;
    private readonly ILocationHandler _locationHandler;

    public Command UpdateWeather { get; }
    public event PropertyChangedEventHandler? PropertyChanged;

    public string? currentTemperatureProp
    {
      get => _currentTemperature;
      set
      {
        if (value != _currentTemperature)
        {
          _currentTemperature = value;
          OnPropertyChanged();
        }
      }
    }
    public string? currentWindSpeedProp
    {
      get => _currentWindSpeed;
      set
      {
        if (value != _currentWindSpeed)
        {
          _currentWindSpeed = value;
          OnPropertyChanged();
        }
      }
    }
    public string? maxWindProp
    {
      get => _maxWind;
      set
      {
        if (value != _maxWind)
        {
          _maxWind = value;
          OnPropertyChanged();
        }
      }
    }
    public string? lowestTempProp
    {
      get => _lowestTemp;
      set
      {
        if (value != _lowestTemp)
        {
          _lowestTemp = value;
          OnPropertyChanged();
        }
      }
    }
    public string? highestTempProp
    {
      get => _highestTemp;
      set
      {
        if (value != _highestTemp)
        {
          _highestTemp = value;
          OnPropertyChanged();
        }
      }
    }
    public Location? currentLocationProp
    {
      get => _currentLocation;
      set
      {
        if (value != _currentLocation)
        {
          _currentLocation = value;
          OnPropertyChanged();

        }
      }
    }
    public Color? maxWindTextColor
    {
      get => _maxWindTextColor;
      set
      {
        if (value != _maxWindTextColor)
        {
          _maxWindTextColor = value;
          OnPropertyChanged();
        }
      }
    }

    public WeatherViewModel(IParser parser, ILocationHandler locationHandler, IWeatherApi weatherApi)
    {
      _locationHandler = locationHandler;
      _weatherApi = weatherApi;
      _parser = parser;

      UpdateWeather = new Command(RefreshTemperatureAndWind);
      RefreshTemperatureAndWind();
    }

    public async void RefreshTemperatureAndWind()
    {
      Debug.WriteLine("refreshing weather data");
      currentLocationProp = await _locationHandler.GetUserGeolocation();
      if (currentLocationProp != null)
      {
        string? data = await _weatherApi.GetWeatherDataAsync(currentLocationProp);
        double? temperature = _parser.ExtractCurrentTemperature(data);
        double? windSpeed = _parser.ExtractCurrentWindSpeed(data);
        double? maxWind = _parser.ExtractMaxWindSpeed(data);
        double? highestTemp = _parser.ExtractHighestTemperature(data);
        double? lowestTemp = _parser.ExtractLowestTemperature(data);

        currentWindSpeedProp = windSpeed != null ? $"{Math.Round((Decimal)windSpeed, 1)} m/s" : "N/A";
        currentTemperatureProp = $"{temperature}°C";
        maxWindProp = maxWind != null ? $"{Math.Round((Decimal)maxWind, 1)} m/s" : "N/A";
        highestTempProp = $"{highestTemp}°C";
        lowestTempProp = $"{lowestTemp}°C";

        maxWindTextColor = maxWind > 10 ? Colors.Red : Colors.Black;

        Debug.WriteLine($"success!");
      }
      else
      {
        Debug.WriteLine($"location not available");
        currentWindSpeedProp = $"Not available";
        currentTemperatureProp = $"Not available";
      }
    }
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
