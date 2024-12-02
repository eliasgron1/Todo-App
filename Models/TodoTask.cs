namespace Models
{
  public class TodoTask
  {
    public int TodoTaskId { get; set; }
    public string TaskDescription { get; set; }
    public bool IsCompleted { get; set; }

    public int TodoListId { get; set; }

    public TodoList TodoList { get; set; }
  }
}
