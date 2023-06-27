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

        [HttpPut("{StatsId}")]
        public async Task<IActionResult> UpdateStatsSwimmingStyle(int SwimmingStyleId, int StatsId,
                                  [FromBody] StatsSwimmingstyleForUpdateDto statsSwimmingStyle)
        {
            if (!await _swimmingStyleRepository.SwimmingStyleExistAsync(SwimmingStyleId))
            {
                _logger.LogInformation($"Swimming style with id {SwimmingStyleId} wasn't found when accessing of Stats of swimming style ");
                return NotFound();
            }
            var statsSwimmingStyleFromEntity = await _swimmingStyleRepository.GetStatOfSwimmingStyleAsync(SwimmingStyleId, StatsId);
            if (statsSwimmingStyleFromEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(statsSwimmingStyle, statsSwimmingStyleFromEntity);

            await _swimmingStyleRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{StatsId}")]
        public async Task<IActionResult> PartiallyUpdateStatsSwimmingStyle(int SwimmingStyleId, int StatsId,
                                             [FromBody] JsonPatchDocument<StatsSwimmingstyleForUpdateDto> patchDoc)
        {
            if (!await _swimmingStyleRepository.SwimmingStyleExistAsync(SwimmingStyleId))
            {
                _logger.LogInformation($"Swimming style with id {SwimmingStyleId} wasn't found when accessing of Stats of swimming style ");
                return NotFound();
            }
            var statsSwimmingStyleFromEntity = await _swimmingStyleRepository.GetStatOfSwimmingStyleAsync(SwimmingStyleId, StatsId);
            if (statsSwimmingStyleFromEntity == null)
            {
                return NotFound();
            }
            var statsSwimmingStyleToPatch = _mapper.Map<StatsSwimmingstyleForUpdateDto>(statsSwimmingStyleFromEntity);

            patchDoc.ApplyTo(statsSwimmingStyleToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(statsSwimmingStyleToPatch))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(statsSwimmingStyleToPatch, statsSwimmingStyleFromEntity);
            await _swimmingStyleRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{StatsId}")]
        public async Task<IActionResult> DeleteStatsSwimmingStyle(int SwimmingStyleId, int StatsId)
        {
            if (!await _swimmingStyleRepository.SwimmingStyleExistAsync(SwimmingStyleId))
            {
                _logger.LogInformation($"Swimming style with id {SwimmingStyleId} wasn't found when accessing of Stats of swimming style ");
                return NotFound();
            }

            var statsSwimmingStyleFromEntity = await _swimmingStyleRepository.GetStatOfSwimmingStyleAsync(SwimmingStyleId, StatsId);
            if (statsSwimmingStyleFromEntity == null)
            {
                return NotFound();
            }
            _swimmingStyleRepository.DeleteStatSwimmingStyle(statsSwimmingStyleFromEntity);
            await _swimmingStyleRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
