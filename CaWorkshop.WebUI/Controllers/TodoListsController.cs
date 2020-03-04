using CaWorkshop.Application.TodoLists.Commands.CreateTodoList;
using CaWorkshop.Application.TodoLists.Commands.DeleteTodoList;
using CaWorkshop.Application.TodoLists.Commands.UpdateTodoList;
using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
using CaWorkshop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaWorkshop.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoListsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/TodoLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoLists()
        {
            return await _mediator.Send(new GetTodoListsQuery());
        }

        // POST: api/TodoLists
        [HttpPost]
        public async Task<ActionResult<int>> PostTodoList(
            CreateTodoListCommand command)
        {
            return await _mediator.Send(command);
        }

        // PUT: api/TodoLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoList(int id,
            UpdateTodoListCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/TodoLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList(int id)
        {
            await _mediator.Send(new DeleteTodoListCommand { Id = id });

            return NoContent();
        }
    }
}