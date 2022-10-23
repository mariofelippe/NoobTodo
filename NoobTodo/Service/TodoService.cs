using NoobTodo.Entities;
using NoobTodo.Interfaces.Service;
using NoobTodo.Interfaces.Repository;

namespace NoobTodo.Service
{
    public class TodoService : IBaseService<Todo>
    {
        private readonly IBaseRepository<Todo> _repository;
       public TodoService(IBaseRepository<Todo> repository)
        {
            _repository = repository;
        }
        public bool Add(Todo todo)
        {
            return _repository.Add(todo);
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
