using AutoMapper;
using CaWorkshop.Application.Common.Mappings;
using CaWorkshop.Domain.Entities;
using System.Collections.Generic;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists
{
    public class TodoListDto : IMapFrom<TodoList>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IList<TodoItemDto> Items { get; set; }
    }
}