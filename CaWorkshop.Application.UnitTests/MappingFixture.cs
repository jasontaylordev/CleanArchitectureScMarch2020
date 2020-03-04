using AutoMapper;

namespace CaWorkshop.Application.UnitTests
{
    public class MappingFixture
    {
        public MappingFixture()
        {
            Mapper = MapperFactory.Create();
        }

        public IMapper Mapper { get; set; }
    }
}