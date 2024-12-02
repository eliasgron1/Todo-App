namespace Models
{
  public class TodoList
  {
    public int TodoListId { get; set; }
    public string Name { get; set; }

    public ICollection<TodoTask> TodoTasks { get; set; }
  }
}
