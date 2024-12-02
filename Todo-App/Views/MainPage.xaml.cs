using Todo_App.ViewModels;

namespace Todo_App
{
  public partial class MainPage : ContentPage
  {
    public MainPage(WeatherViewModel weatherViewModel, TodoViewModel todoViewModel)
    {
      InitializeComponent();
      BindingContext = new
      {
        Weather = weatherViewModel,
        Todo = todoViewModel
      };
    }
  }
}
