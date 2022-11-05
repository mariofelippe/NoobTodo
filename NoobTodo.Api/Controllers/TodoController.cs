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
            ReadTodoDto todoDto = _mapper.Map<ReadTodoDto>(todo);
            return Ok(todoDto);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTodo(int id, [FromBody] UpdateTodoDto updateTodo) 
        {
            var todo = _service.GetById(id);
            if(todo == null)
            {
                return NotFound();
            }
            _mapper.Map(updateTodo, todo);
            _service.Update(id, todo);
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
