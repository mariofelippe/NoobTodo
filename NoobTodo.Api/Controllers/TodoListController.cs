using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoobTodo.Data;
using NoobTodo.Entities;
using NoobTodo.Service;

namespace NoobTodo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : Controller
    {
        private readonly TodoListService _service;
        private readonly TodoListRepository _repository;

        public TodoListController(TodoContext context, IMapper mapper)
        {
            _repository = new TodoListRepository(context);
            _service = new TodoListService(_repository);
        }
        [HttpGet]
        public IEnumerable<TodoList> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost]
        public IActionResult CreateTodoList([FromBody] TodoList todoList)
        {
            _service.Add(todoList);
            return CreatedAtAction(nameof(GetAll), new { id = todoList.Id }, todoList);

        }
    }
}
