
namespace NoobTodo.DTOs
{
    public class ReadTodoDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? TaskDate { get; set; }
        public bool IsDone { get; set; }
        
        public bool IsLate {

            get
            {
                if (TaskDate.HasValue)
                {
                    bool late = TaskDate.Value < DateTime.Now && !IsDone ? true : false;
                    return late;
                }
                return false;
            }
           
        }
        public TimeSpan? TimeDelay
        {
            get
            {
                var timeDelay = IsLate ? DateTime.Now - TaskDate : DateTime.Now - DateTime.Now;
                return timeDelay;
            }
        }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
    }
}
