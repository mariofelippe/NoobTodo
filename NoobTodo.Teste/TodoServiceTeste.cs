using NoobTodo.Service;
using NoobTodo.Data;
using Xunit;
using Microsoft.EntityFrameworkCore;
using NoobTodo.Entities;

namespace NoobTodo.Teste
{
    public class TodoServiceTeste
    {
        private readonly TodoService _service;
        private readonly TodoRepository _repository;
        private readonly TodoContext _context;
        private static DbContextOptions<TodoContext> dbContextOptions = new DbContextOptionsBuilder<TodoContext>()
            .UseInMemoryDatabase("noob").Options;

        public TodoServiceTeste()
        {

            _context = new TodoContext(dbContextOptions);
            _context.Database.EnsureCreated();
            _repository = new TodoRepository(_context);
            _service = new TodoService(_repository);

        }

        [Fact]
        public void DeveAdionarUmTodo()
        {
            //arrange
            var todo = new Todo("Tomar cafe") { Description = "Teste", TaskDate = System.DateTime.Now};
            //act
            //assert
            Assert.True(_service.Add(todo));
        }
    }
}
