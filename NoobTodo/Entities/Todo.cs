
namespace NoobTodo.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TaskDate { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Todo(string title)
        {
            Title = title;
        }
    }
}
