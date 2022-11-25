
namespace NoobTodo.DTOs
{
    public class ReadTodoListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<ReadTodoDto> Todos { get; set; } = new List<ReadTodoDto>();
        public int TodoCount
        {
            get
            {
                return Todos.Count;
            }
        }  
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
