
namespace NoobTodo.Entities
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public virtual List<Todo> Todos { get; set; } = new List<Todo>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public TodoList(string title)
        {
            Title = title;
        }

        public void AddTodo(Todo todo)
        {
            Todos.Add(todo);
        }
    }
}
