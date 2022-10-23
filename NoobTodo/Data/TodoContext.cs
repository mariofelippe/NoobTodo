using Microsoft.EntityFrameworkCore;
using NoobTodo.Entities;

namespace NoobTodo.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options): base(options)
        {

        }

        DbSet<Todo> Todos { get; set; }
    }
}
