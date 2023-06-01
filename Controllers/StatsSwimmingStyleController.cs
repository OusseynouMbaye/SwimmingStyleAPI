using Microsoft.AspNetCore.Mvc;
using SwimmingStyleAPI.Models;

namespace SwimmingStyleAPI.Controllers
{
    [Route("api/swimmingStyle/{SwimmingStyleId}/StatsSwimmingStyle")] //[Route("api/[controller]")]
    [ApiController]
    public class StatsSwimmingStyleController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<StatsSwimmingstyleDto>> GetStatsOfSwimmingStyle(int SwimmingStyleId)
        {
            var swimmingStyle = SwimmingStyleDataStore.Current.SwimmingStyles
                .FirstOrDefault(x => x.SwimmingStyleId == SwimmingStyleId);
            if (swimmingStyle == null)
            {
                return NotFound();
            }


            return Ok(swimmingStyle.StatsOfSwimmingStyle);
        }

        // create to get by id
        [HttpGet("{StatsId}")]
        public ActionResult<StatsSwimmingstyleDto> GetswimmingstyleById(int SwimmingStyleId, int StatsId)
        {
            var swimmingStyle = SwimmingStyleDataStore.Current.SwimmingStyles
                .Find(x => x.SwimmingStyleId == SwimmingStyleId);
            if (swimmingStyle == null)
            {
                return NotFound();
            }

            // find swimming style
            var statsSwimmingStyle = swimmingStyle.StatsOfSwimmingStyle
                .FirstOrDefault(x => x.IdStats == StatsId);
            if (statsSwimmingStyle == null)
            {
                return NotFound();
            }
            return Ok(statsSwimmingStyle);
        }
    }
}
