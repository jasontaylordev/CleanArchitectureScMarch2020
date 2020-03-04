using AutoMapper;
using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
using CaWorkshop.Infrastructure.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaWorkshop.Application.UnitTests.TodoLists.Queries.GetTodoLists
{
    [Collection("QueryTests")]
    public class GetTodoListsQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodoListsQueryTests(TestBaseFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectVm()
        {
            // Arrange
            var query = new GetTodoListsQuery();
            var handler = new GetTodoListsQueryHandler(_context, _mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<TodosVm>();
            result.Lists.Count.ShouldBe(1);
            result.Lists[0].Items.Count.ShouldBe(5);
        }
    }
}