using AutoMapper;

namespace SwimmingStyleAPI.Profiles
{
    public class SwimmingStyleProfile : Profile
    {
        public SwimmingStyleProfile()
        {
            CreateMap<Entitites.SwimmingStyleEntities, Models.SwimmingStyleDto.SwimmingStyleWithoutStatsOfSwimmingStyleDto>();
            CreateMap<Entitites.SwimmingStyleEntities, Models.SwimmingStyleDto.SwimmingStyleDto>();
        }
    }
}
