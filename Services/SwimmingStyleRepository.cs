using Microsoft.EntityFrameworkCore;
using SwimmingStyleAPI.DbContexts;
using SwimmingStyleAPI.Entitites;

namespace SwimmingStyleAPI.Services
{
    public class SwimmingStyleRepository : ISwimmingStyleRepository
    {
        private readonly SwimmingStyleContext _swimmingStyleContext;

        public SwimmingStyleRepository(SwimmingStyleContext swimmingStyleContext)
        {
            _swimmingStyleContext = swimmingStyleContext ?? throw new ArgumentNullException(nameof(swimmingStyleContext));
        }

        public async Task<IEnumerable<SwimmingStyleEntities>> GetAllSwimmingStylesAsync()
        {
            return await _swimmingStyleContext.SwimmingStyles.OrderBy(swimmingStyle => swimmingStyle.Id).ToListAsync();
        }

        public async Task<SwimmingStyleEntities?> GetSwimmingStyleById(int swimmingStyleId, bool includeStatSwimmingStyle)
        {
            if (includeStatSwimmingStyle)
            {
                return await _swimmingStyleContext.SwimmingStyles.Include(swimmingStyle => swimmingStyle.StatsOfSwimmingStyle)
                    .Where(swimmingStyle => swimmingStyle.Id == swimmingStyleId).FirstOrDefaultAsync();
            }

            return await _swimmingStyleContext.SwimmingStyles
                .Where(swimmingStyle => swimmingStyle.Id == swimmingStyleId).FirstOrDefaultAsync();
        }

        public void CreateSwimmingStyle(SwimmingStyleEntities swimmingStyle)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StatsSwimmingstyleEntities>> GetAllStatsOfSwimmingStyle(int SwimmingStyleId)
        {
           return await _swimmingStyleContext.StatsSwimmingStyles.OrderBy(stats => stats.SwimmingStyleEntitiesId == SwimmingStyleId).ToListAsync();
        }

        public async Task<StatsSwimmingstyleEntities?> GetStatsOfSwimmingStyleById(int swimmingStyleId, int statsId)
        {
           return await _swimmingStyleContext.StatsSwimmingStyles.Where(stats => stats.SwimmingStyleEntitiesId == swimmingStyleId && stats.Id == statsId).FirstOrDefaultAsync(); 
        }

    }
}
