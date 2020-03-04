using CaWorkshop.Application.TodoLists.Commands.CreateTodoList;
using CaWorkshop.Infrastructure.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaWorkshop.Application.UnitTests.TodoLists.Commands.CreateTodoList
{

    public class CreateTodoListCommandTests : TestBaseFixture
    {
        private readonly ApplicationDbContext _context;

        public CreateTodoListCommandTests()
        {
            _context = base.Context;
        }

        [Fact]
        public async Task Handle_ShouldPersistTodoList()
        {
            var command = new CreateTodoListCommand
            {
                Title = "Bucket List"
            };

            var handler = new CreateTodoListCommandHandler(_context);

            var result = await handler.Handle(command,
                CancellationToken.None);

            var entity = _context.TodoLists.Find(result);

            entity.ShouldNotBeNull();
            entity.Title.ShouldBe(command.Title);
        }
    }
}