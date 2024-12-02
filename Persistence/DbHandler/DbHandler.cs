using Microsoft.EntityFrameworkCore;
using Models;
using System.Diagnostics;

namespace Persistence.DbHandler
{
  public class DbHandler : IDbHandler
  {
    private readonly TodoContext _context;

    public DbHandler(TodoContext context)
    {
      _context = new TodoContext();
    }

    public TodoList CreateTodoList(string listName)
    {
      Debug.WriteLine($"creating new list {listName}");
      var todoList = new TodoList { Name = listName };
      _context.TodoLists.Add(todoList);
      _context.SaveChanges();
      return todoList;
    }

    public TodoTask AddTaskToTodoList(int todoListId, string taskDescription)
    {
      Debug.WriteLine($"adding task {taskDescription} to list");
      var todoList = _context.TodoLists
                             .Include(t => t.TodoTasks)
                             .FirstOrDefault(t => t.TodoListId == todoListId);

      if (todoList == null)
      {
        throw new Exception("TodoList not found when adding task to list");
      }

      var newTask = new TodoTask
      {
        TaskDescription = taskDescription,
        IsCompleted = false,
        TodoListId = todoListId
      };

      _context.TodoTasks.Add(newTask);
      _context.SaveChanges();

      return newTask;
    }

    public List<TodoList> GetTodoLists()
    {
      Debug.WriteLine($"fetching lists");
      return _context.TodoLists
                     .Include(t => t.TodoTasks)
                     .ToList();
    }

    public void DeleteTodoList(int todoListId)
    {
      Debug.WriteLine($"Deleting list id {todoListId}");
      var todoList = _context.TodoLists
                             .Include(t => t.TodoTasks)
                             .FirstOrDefault(t => t.TodoListId == todoListId);

      if (todoList == null)
      {
        throw new Exception("TodoList not found when deleting list");
      }

      _context.TodoLists.Remove(todoList);
      _context.SaveChanges();
    }
  }
}
