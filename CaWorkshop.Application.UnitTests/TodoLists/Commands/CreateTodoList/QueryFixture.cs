using Xunit;

namespace CaWorkshop.Application.UnitTests
{
    [CollectionDefinition("QueryTests")]
    public class QueryFixture
        : ICollectionFixture<TestBaseFixture>
    { }
}