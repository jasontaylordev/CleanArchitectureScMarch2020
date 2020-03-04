using CaWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists
{
    public class TodosVm
    {
        public List<PriorityLevelDto> PriorityLevels
        {
            get
            {
                return Enum.GetValues(typeof(PriorityLevel))
                    .Cast<PriorityLevel>()
                    .Select(p => new PriorityLevelDto
                    {
                        Value = (int)p,
                        Name = p.ToString()
                    })
                    .ToList();
            }
        }

        public List<TodoListDto> Lists { get; set; }
    }
}