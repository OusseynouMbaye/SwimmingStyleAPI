using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SwimmingStyleAPI.Models.StatsDto;

namespace SwimmingStyleAPI.Controllers
{
    [Route("api/swimmingStyle/{SwimmingStyleId}/StatsSwimmingStyle")] //[Route("api/[controller]")]
    [ApiController]
    public class StatsSwimmingStyleController : ControllerBase
    {
        // logger
        private readonly ILogger<StatsSwimmingStyleController> _logger;

        public StatsSwimmingStyleController(ILogger<StatsSwimmingStyleController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public ActionResult<IEnumerable<StatsSwimmingstyleDto>> GetAllStatsOfSwimmingStyle(int SwimmingStyleId)
        {
            try
            {
                //throw new Exception("Exception sample");
                var swimmingStyle = SwimmingStyleDataStore.Current.SwimmingStyles
                             .FirstOrDefault(x => x.SwimmingStyleId == SwimmingStyleId);
                if (swimmingStyle == null)
                {
                    _logger.LogInformation($"Swimming style with id {SwimmingStyleId} was found");
                    return NotFound();
                }
                return Ok(swimmingStyle.StatsOfSwimmingStyle);

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting swimming style with id {SwimmingStyleId}",ex);
                return StatusCode(500, "A problem happened while handling your request");
            }

        }

        [HttpGet("{StatsId}", Name = "GetSwimmingStyleById")]
        public ActionResult<StatsSwimmingstyleDto> GetSwimmingStyleById(int SwimmingStyleId, int StatsId)
        {
            var swimmingStyle = SwimmingStyleDataStore.Current.SwimmingStyles
                .Find(x => x.SwimmingStyleId == SwimmingStyleId);
            if (swimmingStyle == null)
            {
                _logger.LogWarning($"Swimming style with id {SwimmingStyleId} was found");
                return NotFound();
            }


            // find swimming style
            var statsSwimmingStyle = swimmingStyle.StatsOfSwimmingStyle
                .FirstOrDefault(x => x.IdStats == StatsId);
            if (statsSwimmingStyle == null)
            {
                _logger.LogInformation($"stats style with id {StatsId} was found");
                return NotFound();
            }
            return Ok(statsSwimmingStyle);
        }

        [HttpPost]
        public ActionResult<StatsSwimmingstyleDto> CreateStatsSwimmingStyle(int SwimmingStyleId,
            [FromBody] StatsSwimmingstyleDtoForCreation statsSwimmingStyle)
        {
            var swimmingStyle = SwimmingStyleDataStore.Current.SwimmingStyles
                .FirstOrDefault(swimmingStyle => swimmingStyle.SwimmingStyleId == SwimmingStyleId);
            if (swimmingStyle == null)
            {
                return NotFound();
            }

            // need to calculate the ide of the new item 
            var maxStatsId = SwimmingStyleDataStore.Current.SwimmingStyles.SelectMany(
                               c => c.StatsOfSwimmingStyle).Max(p => p.IdStats);
            if (maxStatsId == 0)
            {
                maxStatsId = 1;
            }
            else
            {
                maxStatsId++;
            }

            // need to mapping because we work with swimming style dto and i need to create stats dto
            var finalStatsSwimmingStyle = new StatsSwimmingstyleDto()
            {

                IdStats = maxStatsId,
                Speed = statsSwimmingStyle.Speed,
                Endurance = statsSwimmingStyle.Endurance,
                Technique = statsSwimmingStyle.Technique,
                Difficulty = statsSwimmingStyle.Difficulty
            };

            swimmingStyle.StatsOfSwimmingStyle.Add(finalStatsSwimmingStyle);
            return CreatedAtRoute(
                "GetSwimmingStyleById",
                new
                {
                    SwimmingStyleId = SwimmingStyleId,
                    StatsId = finalStatsSwimmingStyle.IdStats
                },
                finalStatsSwimmingStyle);
            //nameof(GetswimmingstyleById)
        }

        [HttpPut("{StatsId}")]
        public ActionResult<StatsSwimmingstyleDto> UpdateStatsSwimmingStyle(int SwimmingStyleId, int StatsId,
                       [FromBody] StatsSwimmingstyleDtoForUpdate statsSwimmingStyle)
        {
            var swimmingStyle = SwimmingStyleDataStore.Current.SwimmingStyles
                .FirstOrDefault(swimmingStyle => swimmingStyle.SwimmingStyleId == SwimmingStyleId);
            if (swimmingStyle == null)
            {
                return NotFound();
            }

            // find swimming style
            var statsSwimmingStyleFromStore = swimmingStyle.StatsOfSwimmingStyle
                .FirstOrDefault(x => x.IdStats == StatsId);
            if (statsSwimmingStyleFromStore == null)
            {
                return NotFound();
            }

            // need to mapping 
            statsSwimmingStyleFromStore.Speed = statsSwimmingStyle.Speed;
            statsSwimmingStyleFromStore.Endurance = statsSwimmingStyle.Endurance;
            statsSwimmingStyleFromStore.Technique = statsSwimmingStyle.Technique;
            statsSwimmingStyleFromStore.Difficulty = statsSwimmingStyle.Difficulty;
            return NoContent();
        }

        // patch request for update only one property or more with json patch document
        [HttpPatch("{StatsId}")]
        public ActionResult<StatsSwimmingstyleDto> PartiallyUpdateStatsSwimmingStyle(int SwimmingStyleId, int StatsId,
                                  JsonPatchDocument<StatsSwimmingstyleDtoForUpdate> patchDoc)
        {
            var swimmingStyle = SwimmingStyleDataStore.Current.SwimmingStyles
                .FirstOrDefault(swimmingStyle => swimmingStyle.SwimmingStyleId == SwimmingStyleId);
            if (swimmingStyle == null)
            {
                return NotFound();
            }
            // find swimming style
            var statsSwimmingStyleFromStore = swimmingStyle.StatsOfSwimmingStyle
                .FirstOrDefault(x => x.IdStats == StatsId);
            if (statsSwimmingStyleFromStore == null)
            {
                return NotFound();
            }
            // need to mapping 
            var statsSwimmingStyleToPatch =
                new StatsSwimmingstyleDtoForUpdate()
                {
                    Speed = statsSwimmingStyleFromStore.Speed,
                    Endurance = statsSwimmingStyleFromStore.Endurance,
                    Technique = statsSwimmingStyleFromStore.Technique,
                    Difficulty = statsSwimmingStyleFromStore.Difficulty
                };

            patchDoc.ApplyTo(statsSwimmingStyleToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(statsSwimmingStyleToPatch))
            {
                return BadRequest(ModelState);
            }

            // need to mapping 
            statsSwimmingStyleFromStore.Speed = statsSwimmingStyleToPatch.Speed;
            statsSwimmingStyleFromStore.Endurance = statsSwimmingStyleToPatch.Endurance;
            statsSwimmingStyleFromStore.Technique = statsSwimmingStyleToPatch.Technique;
            statsSwimmingStyleFromStore.Difficulty = statsSwimmingStyleToPatch.Difficulty;
            return NoContent();
        }


        [HttpDelete("{StatsId}")]
        public ActionResult DeleteStatsSwimmingStyle(int SwimmingStyleId, int StatsId)
        {
            var swimmingStyle = SwimmingStyleDataStore.Current.SwimmingStyles
                .FirstOrDefault(swimmingStyle => swimmingStyle.SwimmingStyleId == SwimmingStyleId);
            if (swimmingStyle == null)
            {
                return NotFound();
            }
            // find swimming style
            var statsSwimmingStyleFromStore = swimmingStyle.StatsOfSwimmingStyle
                .FirstOrDefault(x => x.IdStats == StatsId);
            if (statsSwimmingStyleFromStore == null)
            {
                return NotFound();
            }
            swimmingStyle.StatsOfSwimmingStyle.Remove(statsSwimmingStyleFromStore);
            return NoContent();
        }
    }
}
