using Models;
using Persistence.DbHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_App.Services.Todo
{
  public interface ITodoService
  {
    public List<TodoList> GetTodoListsInDb();
    public void CreateTodoList(string listName);
    public void AddTaskToTodoList(int listId, string taskDescription);
    public void DeleteTodoList(int listId);
  }
}
