using NoobTodo.Entities;
using NoobTodo.Data;
using NoobTodo.Interfaces.Repository;

namespace NoobTodo.Data
{
    public class TodoRepository : IBaseRepository<Todo>
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public bool Add(Todo todo)
        {
            try
            {
                _context.Todos.Add(todo);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Todo> GetAll()
        {
            try
            {
                return _context.Todos;
            }
            catch
            {
                throw new Exception("Erro");
            }
        }

        public Todo GetById(int id)        {
            try
            {
                return _context.Todos.FirstOrDefault(t => t.Id == id);
            }
            catch
            {
                throw new Exception($"Erro ao obter a tarefa com Id {id}!");
            }
            
        }

        public bool Update(int id, Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
