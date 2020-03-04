using AutoMapper;
using CaWorkshop.Infrastructure.Persistence;
using System;

namespace CaWorkshop.Application.UnitTests
{
    public class TestBaseFixture : IDisposable
    {
        public TestBaseFixture()
        {
            Context = DbContextFactory.Create();
            Mapper = MapperFactory.Create();
        }

        public ApplicationDbContext Context { get; }

        public IMapper Mapper { get; }

        public void Dispose()
        {
            DbContextFactory.Destroy(Context);
        }
    }
}