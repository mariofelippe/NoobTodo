using AutoMapper;
using NoobTodo.DTOs;
using NoobTodo.Entities;

namespace NoobTodo.Profiles
{
    public class TodoProfile : Profile
    {
       public TodoProfile()
        {
            CreateMap<CreateTodoDto, Todo>();
            CreateMap<Todo, CreateTodoDto>();
            CreateMap<UpdateTodoDto, Todo>();            
        }
    }
}
