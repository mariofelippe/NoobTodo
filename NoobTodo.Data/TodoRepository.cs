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
                _context.Add(todo);
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
            throw new NotImplementedException();
        }

        public Todo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
