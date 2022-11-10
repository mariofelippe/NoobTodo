using NoobTodo.Entities;
using NoobTodo.Data;
using NoobTodo.Interfaces.Repository;

namespace NoobTodo.Data
{
    public class TodoListRepository : IBaseRepository<TodoList>
    {
        private readonly TodoContext _context;

        public TodoListRepository(TodoContext context)
        {
            _context = context;
        }

        public bool Add(TodoList todoList)
        {
            try
            {
                _context.TodoLists.Add(todoList);
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
            try
            {
                TodoList todoList = _context.TodoLists.Find(id);
                if (todoList == null)
                    return false;
                _context.TodoLists.Remove(todoList);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<TodoList> GetAll()
        {
            try
            {
                return _context.TodoLists;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TodoList GetById(int id)
        {
            try
            {
                return _context.TodoLists.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool Update(int id, TodoList entity)
        {
            throw new NotImplementedException();
        }
    }
}
