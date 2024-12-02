using System.Diagnostics;
using Todo_App.Services.GeoLocation;

namespace Todo_App.Services.GeoLocation
{
  internal class LocationService : ILocationHandler
  {
    private readonly IPermissionHandler _permissionHandler;

    public LocationService(IPermissionHandler permissionHandler)
    {
      _permissionHandler = permissionHandler;
    }

    public async Task<Location?> GetUserGeolocation()
    {
      bool permissioStatusGranted = await _permissionHandler.RequestLocationPermissionAsync();
      Debug.WriteLine($"permission for location granted: {permissioStatusGranted}");

      if (permissioStatusGranted)
      {
        var location = await Geolocation.GetLastKnownLocationAsync();
        if (location != null)
        {
          return location;
        }
        else
        {
          Debug.WriteLine("error getting location");
          return null;
        }
      }
      Debug.WriteLine("location permission not granted");
      return null;
    }
  }
}
