using System.ComponentModel.DataAnnotations;

namespace NoobTodo.DTOs
{
    public class CreateTodoListDto
    {
        [Required(ErrorMessage="O titulo deve ser informado.")]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
