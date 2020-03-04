using CaWorkshop.Application.TodoItems.Commands.CreateTodoItem;
using CaWorkshop.Application.TodoItems.Commands.DeleteTodoItem;
using CaWorkshop.Application.TodoItems.Commands.UpdateTodoItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CaWorkshop.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<long>> PostTodoItem(
            CreateTodoItemCommand command)
        {
            return await _mediator.Send(command);
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id,
            UpdateTodoItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            await _mediator.Send(new DeleteTodoItemCommand { Id = id });

            return NoContent();
        }
    }
}
