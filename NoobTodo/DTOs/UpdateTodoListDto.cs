using System.ComponentModel.DataAnnotations;

namespace NoobTodo.DTOs
{
    public class UpdateTodoListDto
    {
        [Required(ErrorMessage = "O Titulo deve ser informado!")]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime UpdatedAt { get; } = DateTime.Now;
    }
}
