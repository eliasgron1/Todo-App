namespace Todo_App.Services.GeoLocation
{
  public interface ILocationHandler
  {
    public Task<Location?> GetUserGeolocation();
  }
}
