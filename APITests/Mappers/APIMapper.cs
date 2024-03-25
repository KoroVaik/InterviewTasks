using APITests.Mappers.Configurations;
using AutoMapper;

namespace APITests.Mappers
{
    public static class APIMapper
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<LoginMapperConfigurations>();
            });

            return new Mapper(config);
        }
    }
}
