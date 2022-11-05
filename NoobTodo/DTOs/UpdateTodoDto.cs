using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobTodo.DTOs
{
    public class UpdateTodoDto
    {
        [Required(ErrorMessage = "O titulo deve ser informado!")]
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? TaskDate { get; set; }
        public bool IsDone { get; set; }        
        public DateTime UpdatedAt { get; } = DateTime.Now;
    }
}
