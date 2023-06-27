using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SwimmingStyleAPI.Entitites;
using SwimmingStyleAPI.Models.StatsDto;
using SwimmingStyleAPI.Services.Interfaces;

namespace SwimmingStyleAPI.Controllers
{
    [Route("api/swimmingStyle/{SwimmingStyleId}/StatsSwimmingStyle")] //[Route("api/[controller]")]
    [ApiController]
    public class StatsSwimmingStyleController : ControllerBase
    {
        // logger
        private readonly ILogger<StatsSwimmingStyleController> _logger;
        private readonly ISwimmingStyleRepository _swimmingStyleRepository;
        private readonly IMapper _mapper;

        public StatsSwimmingStyleController(ISwimmingStyleRepository swimmingStyleRepository, ILogger<StatsSwimmingStyleController> logger, IMapper mapper)
        {
            _swimmingStyleRepository = swimmingStyleRepository ?? throw new ArgumentNullException(nameof(swimmingStyleRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatsSwimmingstyleDto>>> GetStatsOfSwimmingStyle(int SwimmingStyleId)
        {
            if (!await _swimmingStyleRepository.SwimmingStyleExistAsync(SwimmingStyleId))
            {
                _logger.LogInformation($"Swimming style with id {SwimmingStyleId} wasn't found when accessing of Stats of swimming style ");
                return NotFound();
            }

            var statsOfswimmingStyle = await _swimmingStyleRepository.GetStatsOfSwimmingStyleAsync(SwimmingStyleId);
            return Ok(_mapper.Map<IEnumerable<StatsSwimmingstyleDto>>(statsOfswimmingStyle));

        }

        [HttpGet("{StatsId}", Name = "GetStatOfSwimmingStyle")]
        public async Task<ActionResult<StatsSwimmingstyleDto>> GetStatOfSwimmingStyle(int SwimmingStyleId, int StatsId)
        {
            if (!await _swimmingStyleRepository.SwimmingStyleExistAsync(SwimmingStyleId))
            {
                _logger.LogInformation($"Swimming style with id {SwimmingStyleId} wasn't found when accessing of Stats of swimming style ");
                return NotFound();
            }

            var statsOfswimmingStyle = await _swimmingStyleRepository.GetStatOfSwimmingStyleAsync(SwimmingStyleId, StatsId);
            if (statsOfswimmingStyle == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StatsSwimmingstyleDto>(statsOfswimmingStyle));


        }
        [HttpPost]
        public async Task<ActionResult<StatsSwimmingstyleDto>> CreateStatsSwimmingStyle(int SwimmingStyleId,
                       [FromBody] StatsSwimmingstyleForCreationDto statsSwimmingStyle)
        {
            if (!await _swimmingStyleRepository.SwimmingStyleExistAsync(SwimmingStyleId))
            {
                _logger.LogInformation($"Swimming style with id {SwimmingStyleId} wasn't found when accessing of Stats of swimming style ");
                return NotFound();
            }

            var finalStatSwimmingStyle = _mapper.Map<StatsSwimmingstyleEntities>(statsSwimmingStyle);

            await _swimmingStyleRepository.AddStatsForSwimmingStyleAsync(SwimmingStyleId, finalStatSwimmingStyle);

            await _swimmingStyleRepository.SaveChangesAsync();

            var createdStatsSwimmingStyleToReturn = _mapper.Map<StatsSwimmingstyleDto>(finalStatSwimmingStyle);

            return CreatedAtRoute("GetStatOfSwimmingStyle", new
            {
                SwimmingStyleId = SwimmingStyleId,
                StatsId = createdStatsSwimmingStyleToReturn.Id
            }, createdStatsSwimmingStyleToReturn);
        }

        /*      [HttpPost]
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
        */
    }
}
