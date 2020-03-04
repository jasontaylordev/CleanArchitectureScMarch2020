using CaWorkshop.Application.TodoLists.Commands.CreateTodoList;
using CaWorkshop.Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace CaWorkshop.Application.UnitTests.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandValidatorTests : TestBaseFixture
    {
        private readonly ApplicationDbContext _context;

        public CreateTodoListCommandValidatorTests()
        {
            _context = Context;
        }

        [Fact]
        public void IsValid_ShouldBeTrue_WhenListTitleIsUnique()
        {
            var command = new CreateTodoListCommand
            {
                Title = "Bucket List",
            };

            var validator = new CreateTodoListCommandValidator(_context);

            var result = validator.Validate(command);

            // TODO: Need to check that the unique title rule is valid, even though other rules may have failed.
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenListTitleIsNotUnique()
        {
            var command = new CreateTodoListCommand
            {
                Title = "Death List Five"
            };

            var validator = new CreateTodoListCommandValidator(_context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}