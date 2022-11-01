using Microsoft.AspNetCore.Mvc;
using NoobTodo.Entities;
using NoobTodo.Data;
using NoobTodo.Interfaces.Repository;
using NoobTodo.Interfaces.Service;
using NoobTodo.Service;

namespace NoobTodo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {

        private readonly TodoRepository _repository;
        private readonly TodoService _service;
        
        public TodoController(TodoContext context)
        {
            _repository = new TodoRepository(context);
            _service = new TodoService(_repository);
        }
        [HttpGet]
        public IEnumerable<Todo> GetTodos()
        {
            return _service.GetAll();
        }
    }
}
