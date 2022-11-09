using Xunit;
using NoobTodo.Entities;

namespace NoobTodo.Teste
{
    public class TodoListTeste
    {
        [Fact]
        public void DeveriaCriarUmaListaDeTaregas()
        {
            // arrange
            string title = "Não iniciado";
            string description = "Tarefas que não ainda não foram iniciadas";
            //act
            TodoList listaTarefas = new TodoList(title){  Description = description };
            // assert
            Assert.Equal(title, listaTarefas.Title);
            Assert.Equal(description, listaTarefas.Description);

        }

        [Fact]
        public void DeveriaAdicionarUmaTarefaNaLista()
        {
            //arrange
            TodoList listTodo = new TodoList("Em andamento");
            Todo todo = new Todo("Mandar o relatório por e-mail");
            //act
            listTodo.AddTodo(todo);
            //assert
            Assert.True(listTodo.Todos.Count > 0);
        }
    }
}
