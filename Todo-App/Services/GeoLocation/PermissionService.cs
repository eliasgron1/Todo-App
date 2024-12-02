using System.Diagnostics;


namespace Todo_App.Services.GeoLocation
{
  internal class PermissionService : IPermissionHandler
  {
    public async Task<bool> RequestLocationPermissionAsync()
    {
      try
      {
        var locationPermissionStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
        if (locationPermissionStatus != PermissionStatus.Granted)
        {
          locationPermissionStatus = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        }
        return locationPermissionStatus == PermissionStatus.Granted;
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"exception ocurred when initializing app permissions: {ex.Message}");
        return false;
      }
    }
  }
}
