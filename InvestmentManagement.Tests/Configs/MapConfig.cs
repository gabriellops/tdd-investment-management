using AutoMapper;

namespace InvestmentManagement.Tests.Configs
{
    public static class MapConfig
    {
        public static IMapper Get()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InvestmentManagement.API.Profiles.MappingProfile());
            });

            return mockMapper.CreateMapper();
        }
    }
}