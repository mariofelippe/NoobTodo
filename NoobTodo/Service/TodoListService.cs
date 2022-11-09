using NoobTodo.Entities;
using NoobTodo.Interfaces.Service;
using NoobTodo.Interfaces.Repository;

namespace NoobTodo.Service
{
    public class TodoListService : IBaseService<TodoList>
    {
        private readonly IBaseRepository<TodoList> _repository;
        public TodoListService(IBaseRepository<TodoList> repository)
        {
            _repository = repository;
        }
        public bool Add(TodoList todoList)
        {
           return _repository.Add(todoList);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoList> GetAll()
        {
            throw new NotImplementedException();
        }

        public TodoList GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, TodoList entity)
        {
            throw new NotImplementedException();
        }
    }
}
