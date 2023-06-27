using AutoMapper;

namespace SwimmingStyleAPI.Profiles
{
    public class StatsOfSwimmingStyleProfile : Profile
    {
        public StatsOfSwimmingStyleProfile()
        {
            CreateMap<Entitites.StatsSwimmingstyleEntities, Models.StatsDto.StatsSwimmingstyleDto>();
            CreateMap<Models.StatsDto.StatsSwimmingstyleForCreationDto, Entitites.StatsSwimmingstyleEntities>();
            CreateMap<Models.StatsDto.StatsSwimmingstyleForUpdateDto, Entitites.StatsSwimmingstyleEntities>();
            CreateMap<Entitites.StatsSwimmingstyleEntities, Models.StatsDto.StatsSwimmingstyleForUpdateDto>();
        }
    }
}
