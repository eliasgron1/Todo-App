namespace Todo_App.Util
{
  public interface IParser
  {
    public double? ExtractCurrentTemperature(string? data);
    public double? ExtractCurrentWindSpeed(string? data);
    public double? ExtractMaxWindSpeed(string? data);
    public double? ExtractLowestTemperature(string? data);
    public double? ExtractHighestTemperature(string? data);
  }
}
