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
            // arrange
            Assert.Equal(title, listaTarefas.Title);
            Assert.Equal(description, listaTarefas.Description);

        }
    }
}
