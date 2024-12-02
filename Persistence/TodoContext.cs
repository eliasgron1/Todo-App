using Microsoft.EntityFrameworkCore;
using Models;

namespace Persistence
{
  public class TodoContext : DbContext
  {
    public DbSet<TodoList> TodoLists { get; set; }
    public DbSet<TodoTask> TodoTasks { get; set; }

    public string DbPath { get; }

    public TodoContext()
    {
      var folder = Environment.SpecialFolder.LocalApplicationData;
      var path = Environment.GetFolderPath(folder);
      DbPath = Path.Join(path, "todoapp.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      options.UseSqlite($"Data Source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // Configure the relationship between TodoList and TodoTask
      modelBuilder.Entity<TodoList>()
          .HasMany(t => t.TodoTasks)
          .WithOne(t => t.TodoList)
          .HasForeignKey(t => t.TodoListId);

    }
  }
}
