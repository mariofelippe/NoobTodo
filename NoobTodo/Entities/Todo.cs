
namespace NoobTodo.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        private string _title;
        public string Title 
        { 
            get { return _title; }
            set { 
                if(value == string.Empty || value == null)                
                    throw new ArgumentException("Titulo não informado!");                
                _title = value;
            }
        }
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
