using NoobTodo.Service;
using NoobTodo.Data;
using Xunit;
using Microsoft.EntityFrameworkCore;
using NoobTodo.Entities;
using System.Collections.Generic;

namespace NoobTodo.Teste
{
    public class TodoListServiceTeste
    {
        private readonly TodoListService _service;
        private readonly TodoListRepository _repository;
        private readonly TodoContext _context;
        private static DbContextOptions<TodoContext> dbContextOptions = new DbContextOptionsBuilder<TodoContext>()
            .UseInMemoryDatabase("noob").Options;

        public TodoListServiceTeste()
        {
            _context = new TodoContext(dbContextOptions);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _repository = new TodoListRepository(_context);
            _service = new TodoListService(_repository);
        }

        [Fact]
        public void DeveriaAdicionarUmaLista()
        {
            //arrange
            TodoList lista = new TodoList("Lista 0");
            Todo todo = new Todo("Comprar pão");
            lista.AddTodo(todo);

            //act
            var adicionou = _service.Add(lista);
            //assert
            Assert.True(adicionou);

        }
    }
}
