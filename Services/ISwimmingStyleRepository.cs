using SwimmingStyleAPI.Entitites;

namespace SwimmingStyleAPI.Services
{
    public interface ISwimmingStyleRepository
    {
        //bool SaveChanges();
        Task<IEnumerable<SwimmingStyleEntities>> GetAllSwimmingStylesAsync();
        Task<SwimmingStyleEntities?> GetSwimmingStyleById(int swimmingStyleId, bool includeStatSwimmingStyle);
        void CreateSwimmingStyle(SwimmingStyleEntities swimmingStyle);
        /*  void UpdateSwimmingStyle(SwimmingStyleEntities swimmingStyle);
          void DeleteSwimmingStyle(SwimmingStyleEntities swimmingStyle);*/

        Task<IEnumerable<StatsSwimmingstyleEntities>> GetAllStatsOfSwimmingStyle(int SwimmingStyleId);
        Task<StatsSwimmingstyleEntities?> GetStatsOfSwimmingStyleById(int SwimmingStyleId, int statsId);
    }
}
