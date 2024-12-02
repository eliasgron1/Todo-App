using System.Diagnostics;
using System.Text.Json;

namespace Todo_App.Util
{
  internal class Parser : IParser
  {
    public double? ExtractCurrentTemperature(string? data)
    {
      try
      {
        if (data != null)
        {
          JsonDocument jsonData = JsonDocument.Parse(data);
          double currentTemp = jsonData.RootElement
            .GetProperty("current")
            .GetProperty("temperature_2m")
            .GetDouble();
          return currentTemp;
        }
        Debug.WriteLine($"Given data was {data}");
        return null;
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"issue extracting CurrentTemperature: {ex.Message}");
        return null;
      }
    }

    public double? ExtractCurrentWindSpeed(string? data)
    {
      try
      {

        if (data != null)
        {
          JsonDocument jsonData = JsonDocument.Parse(data);
          double currentWind = jsonData.RootElement
            .GetProperty("current")
            .GetProperty("wind_speed_10m")
            .GetDouble();
          return currentWind;
        }
        Debug.WriteLine($"Given data was {data}");
        return null;
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"issue extracting CurrentWindSpeed: {ex.Message}");
        return null;
      }
    }

    public double? ExtractMaxWindSpeed(string? data)
    {
      try
      {
        if (data != null)
        {
          JsonDocument jsonData = JsonDocument.Parse(data);
          double maxWind = jsonData.RootElement
            .GetProperty("daily")
            .GetProperty("wind_speed_10m_max")[0]
            .GetDouble();
          return maxWind;
        }
        Debug.WriteLine($"Given data was {data}");
        return null;
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"issue extracting maxWindSpeed: {ex.Message}");
        return null;
      }
    }

    public double? ExtractLowestTemperature(string? data)
    {
      try
      {
        if (data != null)
        {
          JsonDocument jsonData = JsonDocument.Parse(data);
          double minTemp = jsonData.RootElement
            .GetProperty("daily")
            .GetProperty("temperature_2m_min")[0]
            .GetDouble();
          return minTemp;
        }
        Debug.WriteLine($"Given data was {data}");
        return null;
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"issue extracting lowestTemperature: {ex.Message}");
        return null;
      }
    }

    public double? ExtractHighestTemperature(string? data)
    {
      try
      {
        if (data != null)
        {
          JsonDocument jsonData = JsonDocument.Parse(data);
          double maxTemp = jsonData.RootElement
            .GetProperty("daily")
            .GetProperty("temperature_2m_max")[0]
            .GetDouble();
          return maxTemp;
        }
        Debug.WriteLine($"Given data was {data}");
        return null;
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"issue extracting highestTemperature: {ex.Message}");
        return null;
      }
    }
  }
}

