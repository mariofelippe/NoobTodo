using System;
using Xunit;
using NoobTodo.Entities;

namespace NoobTodo.Teste
{
    public class TodoTeste
    {
        [Fact]
        public void CriaUmTodoValido()
        {
            //arrange
            string title = "Comprar pão";
            string description = "Comprar pão para a festa.";
            DateTime taskDate = DateTime.Parse("10/10/2022 13:00:00");
            bool isDone = false;
            

            //act
            var todo = new Todo(title) {                
                Description = description,
                TaskDate = taskDate,
                IsDone = isDone               
            };

            

            //assert
            Assert.Equal(title, todo.Title);
            Assert.Equal(description, todo.Description);
            Assert.Equal(taskDate, todo.TaskDate);
            Assert.Equal(isDone, todo.IsDone);

        }
        [Fact]
        public void DeveGerarExcecaoTituloVazio()
        {
            //arrange
            //act
            //Asert
            Assert.Throws<ArgumentException>(() => new Todo(""));
        }
        [Fact]
        public void DeveCriarUmTodoSomenteComTitulo()
        {
            //arrange
            string title = "Lavar o carro";
            //act
            var todo = new Todo(title);
            //assert
            Assert.Equal(title, todo.Title);
        }
    }
}
