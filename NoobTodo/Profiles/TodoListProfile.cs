using AutoMapper;
using NoobTodo.DTOs;
using NoobTodo.Entities;

namespace NoobTodo.Profiles
{
    public class TodoListProfile : Profile
    {
        public TodoListProfile()
        {
            CreateMap<TodoList,ReadTodoListDto>();
        }
    }
}
