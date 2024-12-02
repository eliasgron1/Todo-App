using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DbHandler
{
  public interface IDbHandler
  {
    public TodoList CreateTodoList(string listName);
    public TodoTask AddTaskToTodoList(int todoListId, string taskDescription);
    public List<TodoList> GetTodoLists();
    public void DeleteTodoList(int todoListId);
  }
}
