using SwimmingStyleAPI.Entitites;

namespace SwimmingStyleAPI.Services
{
    public interface ISwimmingStyleRepository
    {
        Task<IEnumerable<SwimmingStyleEntities>> GetAllSwimmingStylesAsync();
        Task<SwimmingStyleEntities?> GetSwimmingStyleByIdAsync(int swimmingStyleId, bool includeStatSwimmingStyle);
        void CreateSwimmingStyle(SwimmingStyleEntities swimmingStyle);
        Task<bool> SwimmingStyleExistAsync(int swimmingStyleId);
        /*  void UpdateSwimmingStyle(SwimmingStyleEntities swimmingStyle);
          void DeleteSwimmingStyle(SwimmingStyleEntities swimmingStyle);*/
        Task<bool> SaveChangesAsync();

        Task AddStatsForSwimmingStyleAsync(int swimmingStyleId, StatsSwimmingstyleEntities statsSwimmingstyleEntities);

        Task<IEnumerable<StatsSwimmingstyleEntities>> GetStatsOfSwimmingStyleAsync(int SwimmingStyleId);
        Task<StatsSwimmingstyleEntities?> GetStatOfSwimmingStyleAsync(int SwimmingStyleId, int statsId);
    }
}
