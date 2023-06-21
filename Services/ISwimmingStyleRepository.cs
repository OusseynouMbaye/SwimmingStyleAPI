using SwimmingStyleAPI.Entitites;

namespace SwimmingStyleAPI.Services
{
    public interface ISwimmingStyleRepository
    {
        //bool SaveChanges();
        Task<IEnumerable<SwimmingStyleEntities>> GetAllSwimmingStylesAsync();
        Task<SwimmingStyleEntities?> GetSwimmingStyleById(int swimmingStyleId, bool includeStatSwimmingStyle);
        void CreateSwimmingStyle(SwimmingStyleEntities swimmingStyle);
        Task<bool> SwimmingStyleExistAsync(int swimmingStyleId);
        /*  void UpdateSwimmingStyle(SwimmingStyleEntities swimmingStyle);
          void DeleteSwimmingStyle(SwimmingStyleEntities swimmingStyle);*/

        Task<IEnumerable<StatsSwimmingstyleEntities>> GetStatsOfSwimmingStyleAsync(int SwimmingStyleId);
        Task<StatsSwimmingstyleEntities?> GetStatOfSwimmingStyleAsync(int SwimmingStyleId, int statsId);
    }
}
