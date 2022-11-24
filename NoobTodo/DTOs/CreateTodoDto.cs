
using System.ComponentModel.DataAnnotations;

namespace NoobTodo.DTOs
{
    public class CreateTodoDto
    {
        [Required(ErrorMessage = "O titulo deve ser informado!")]
        public string Title { get ; set; }
        public string? Description { get; set; }
        public DateTime? TaskDate { get; set; }
        public bool IsDone { get; set; }
        public int TodoListId { get; set; }
    }
}
