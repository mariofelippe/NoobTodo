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
            Populate();
        }

        [Fact]
        public void DeveriaAdicionarUmaListaNoBanco()
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

        [Fact]
        public void DeveriaRemoverUmaListaDoBanco()
        {
            //arrange
            int id = 3;
            //act
            bool removed = _service.Delete(id); 
            TodoList todoList = _service.GetById(id);
            //Assert
            Assert.True(removed);
            Assert.Null(todoList);          
            
        }
        [Fact]
        public void DeveriaBuscarListaPorId()
        {
            //arrange
            int id = 1;
            //act
            TodoList todoList = _service.GetById(id);
            //assert
            Assert.NotNull(todoList);
            Assert.Equal(id, todoList.Id);
            
        }
        [Fact]
        public void DeveriaRetornarTodasAsLista()
        {
            //arrange
            List<TodoList> todosLists = new List<TodoList>();
            //act
            var listBase = _service.GetAll().GetEnumerator();
            while (listBase.MoveNext())
            {
                todosLists.Add(listBase.Current);
            }
            Assert.True(4 == todosLists.Count);

        }


        private void Populate()
        {
            var todos = new List<TodoList>()
            {
                new TodoList("Lista 1"),
                new TodoList("Lista 2")
                {
                    Description = "Descrição lista 2", Todos = new List<Todo>()
                {
                    new Todo("Compra leite"),
                    new Todo("Mandar e-mail"){Description = "Uma descrição"}
                }                
                }, 
                new TodoList("Lista 3"),
                new TodoList("Lista 4")
                {
                    Description = "Descrição dessa lista",
                    Todos = new List<Todo>()
                    {
                        new Todo("Essa é uma tarefa")
                        {
                            TaskDate = System.DateTime.Parse("10/11/2022") 
                        }
                    }
                }
            };
            _context.AddRange(todos);
            _context.SaveChanges();
        }
    }
}
