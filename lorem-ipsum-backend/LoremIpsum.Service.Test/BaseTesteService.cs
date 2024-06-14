using AutoMapper;
using LoremIpsum.CrossCutting.Mappings;

namespace LoremIpsum.Service.Test
{
    public class BaseTesteService
    {
        public IMapper Mapper { get; set; }
        public BaseTesteService()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }

        public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.AddProfile(new EntityToDtoProfile()); });

                return config.CreateMapper();
            }
            public void Dispose()
            {

            }
        }
    }
}