using Microsoft.EntityFrameworkCore;
using NoobTodo.Entities;

namespace NoobTodo.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Todo>()
                .HasOne(todo => todo.TodoList)
                .WithMany(todoList => todoList.Todos)
                .HasForeignKey(todo => todo.TodoListId);
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
    }
}
