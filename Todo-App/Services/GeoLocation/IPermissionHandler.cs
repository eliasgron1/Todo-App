namespace Todo_App.Services.GeoLocation
{
  public interface IPermissionHandler
  {
    public Task<bool> RequestLocationPermissionAsync();
  }
}
