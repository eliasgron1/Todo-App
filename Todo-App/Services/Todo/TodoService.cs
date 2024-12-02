using Models;
using Persistence.DbHandler;
using System.Diagnostics;


namespace Todo_App.Services.Todo
{
  internal class TodoService : ITodoService
  {
    private IDbHandler _dbHandler;

    public TodoService(IDbHandler dbHandler)
    {
      _dbHandler = dbHandler;
    }

    public List<TodoList> GetTodoListsInDb()
    {
      Debug.WriteLine("Getting todo lists");
      var lists = _dbHandler.GetTodoLists();
      return lists;
    }

    public void CreateTodoList(string listName)
    {
      _dbHandler.CreateTodoList(listName);
    }

    public void AddTaskToTodoList(int listId, string taskDescription)
    {
      _dbHandler.AddTaskToTodoList(listId, taskDescription);
    }

    public void DeleteTodoList(int listId)
    {
      _dbHandler.DeleteTodoList(listId);
    }

  }
}
