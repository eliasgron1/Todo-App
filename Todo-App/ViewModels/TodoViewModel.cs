using Models;
using Persistence;
using Persistence.DbHandler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Todo_App.Services.Todo;

namespace Todo_App.ViewModels
{
  public class TodoViewModel : INotifyPropertyChanged
  {
    private string? _newTask;
    private string? _newList;
    private IDbHandler _dHandler;
    public event PropertyChangedEventHandler? PropertyChanged;
    public Command AddTaskCommand { get; }
    public Command DeleteListCommand { get; }
    public Command AddListCommand { get; }
    public ObservableCollection<TodoList> ListCollection { get; }
    private TodoList? _selectedTodoList;
    public TodoList? SelectedTodoList
    {
      get => _selectedTodoList;
      set
      {
        _selectedTodoList = value;
        OnPropertyChanged(nameof(SelectedTodoList));
        OnPropertyChanged(nameof(SelectedTodoTasks));
      }
    }
    public ObservableCollection<TodoTask>? SelectedTodoTasks
    {
      get
      {
        if (SelectedTodoList != null && SelectedTodoList.TodoTasks != null)
        {
          return new ObservableCollection<TodoTask>(SelectedTodoList.TodoTasks);
        }
        else
        {
          return null;
        }
      }
    }
    public string? NewListProperty
    {
      get => _newList;
      set
      {
        if (_newList != value)
        {
          _newList = value;
          OnPropertyChanged();
        }
      }
    }
    public string? NewTaskProperty
    {
      get => _newTask;
      set
      {
        if (_newTask != value)
        {
          _newTask = value;
          OnPropertyChanged();
        }
      }
    }

    public TodoViewModel(IDbHandler dbHandler)
    {
      DeleteListCommand = new Command(DeleteList);
      AddListCommand = new Command(AddList);
      AddTaskCommand = new Command(AddTask);
      _dHandler = dbHandler;
      ListCollection = new ObservableCollection<TodoList>(_dHandler.GetTodoLists());
    }

    private void AddTask()
    {
      if (!string.IsNullOrWhiteSpace(NewTaskProperty) && SelectedTodoList != null)
      {
        _dHandler.AddTaskToTodoList(SelectedTodoList.TodoListId, NewTaskProperty);

        OnPropertyChanged(nameof(SelectedTodoTasks));
        NewTaskProperty = string.Empty;
      }
    }

    private void DeleteList()
    {
      if (SelectedTodoList != null)
      {
        _dHandler.DeleteTodoList(SelectedTodoList.TodoListId);
        ListCollection.Remove(SelectedTodoList);

        SelectedTodoList = null;
      }
    }

    public void AddList()
    {
      if (!string.IsNullOrWhiteSpace(NewListProperty))
      {
        var newList = _dHandler.CreateTodoList(NewListProperty);
        ListCollection.Add(newList);
        NewListProperty = string.Empty;
      }
    }
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}