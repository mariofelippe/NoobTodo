using Microsoft.AspNetCore.Mvc;
using NoobTodo.Entities;
using NoobTodo.Data;
using NoobTodo.Interfaces.Repository;
using NoobTodo.Interfaces.Service;
using NoobTodo.Service;
using NoobTodo.DTOs;
using AutoMapper;

namespace NoobTodo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly TodoRepository _repository;
        private readonly TodoService _service;
        
        public TodoController(TodoContext context, IMapper mapper)
        {
            _repository = new TodoRepository(context);
            _service = new TodoService(_repository);
            _mapper = mapper;
        }
        [HttpGet]
        public IEnumerable<Todo> GetTodos()
        {
            return _service.GetAll();
        }
        [HttpPost]
        public IActionResult TodoAdd([FromBody] CreateTodoDto todoDto)
        {
            Todo todo = _mapper.Map<Todo>(todoDto);
            _service.Add(todo);
            return CreatedAtAction(nameof(GetById),new { id = todo.Id },todo);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _service.GetById(id);
            if (todo == null)
                return NotFound();
            return Ok(todo);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTodo(int id, [FromBody] Todo todo) 
        {
            var todoDb = _service.GetById(id);
            if(todoDb== null)
            {
                return NotFound();
            }
            todoDb.Title = todo.Title;
            todoDb.Description = todo.Description;
            _service.Update(id, todoDb);
            return NoContent(); 
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveTodo(int id)
        {
            Todo todo = _service.GetById(id);
            if(todo == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            return NoContent();
        }
    }
}
