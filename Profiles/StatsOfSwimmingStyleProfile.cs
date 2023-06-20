using AutoMapper;

namespace SwimmingStyleAPI.Profiles
{
    public class StatsOfSwimmingStyleProfile : Profile
    {
        public StatsOfSwimmingStyleProfile()
        {
            CreateMap<Entitites.StatsSwimmingstyleEntities, Models.StatsDto.StatsSwimmingstyleDto>();
        }
    }
}
