using Microsoft.Extensions.Logging;
using Persistence;
using Persistence.DbHandler;
using Todo_App.Services.GeoLocation;
using Todo_App.Services.Todo;
using Todo_App.Services.Weather;
using Todo_App.Util;
using Todo_App.ViewModels;

namespace Todo_App
{
  public static class MauiProgram
  {
    public static MauiApp CreateMauiApp()
    {
      var builder = MauiApp.CreateBuilder();
      builder
        .UseMauiApp<App>()
        .ConfigureFonts(fonts =>
        {
          fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
          fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });

      builder.Services.AddSingleton<MainPage>();

      builder.Services.AddSingleton<WeatherViewModel>();
      builder.Services.AddSingleton<IParser, Parser>();
      builder.Services.AddSingleton<ILocationHandler, LocationService>();
      builder.Services.AddSingleton<IPermissionHandler, PermissionService>();
      builder.Services.AddSingleton<IWeatherApi, OpenMeteoApi>();

      builder.Services.AddSingleton<TodoViewModel>();
      builder.Services.AddSingleton<IDbHandler, DbHandler>();
      builder.Services.AddSingleton<TodoContext>();


#if DEBUG
      builder.Logging.AddDebug();
#endif

      return builder.Build();
    }
  }
}
