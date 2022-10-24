using NoobTodo.Service;
using NoobTodo.Data;
using Xunit;
using Microsoft.EntityFrameworkCore;
using NoobTodo.Entities;
using System.Collections.Generic;

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
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _repository = new TodoRepository(_context);
            _service = new TodoService(_repository);
            Pupular();

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
        [Fact]
        public void DeveRetornarUmTodo()
        {
            //arrange
            string title = "Teste 2";
            //act
            var todo = _service.GetById(2);
            //assert
            Assert.Equal(title, todo.Title);
        }
     
        [Fact]
        public void DeveRetornarTodosTodos()
        {
            //arrange
            //act
            var todos = _repository.GetAll().GetEnumerator();
            var listaTodos = new List<Todo>();
            while (todos.MoveNext())
            {
                listaTodos.Add(todos.Current);
            }
            //assert
            Assert.True(listaTodos.Count > 1);
        }

        [Fact]
        public void DeveAtualizarUmTodo()
        {
            //arrange
            var novoTitulo = "Atualização do todo 4";
            var novaDescricao = "Descrição atualizada";
            var todo = _repository.GetById(4);

            //act
            todo.Title = novoTitulo;
            todo.Description = novaDescricao;
            var atualizou = _repository.Update(4, todo);
            var todoAtualizado = _repository.GetById(4);

            //assert
            Assert.True(atualizou);
            Assert.Equal(novoTitulo,todoAtualizado.Title);
            Assert.Equal(novaDescricao,todoAtualizado.Description);

        }

        private void Pupular()
        {
            var todos = new List<Todo>()
            {
                new Todo("Teste 1"){Description = "Teste 1"},
                new Todo("Teste 2"){Description = "Teste 2"},
                new Todo("Teste 3"){Description = "Teste 3"},
                new Todo("Teste 4"){Description = "Teste 4"},
            };
            _context.AddRange(todos);
            _context.SaveChanges();
        }
    }
}
