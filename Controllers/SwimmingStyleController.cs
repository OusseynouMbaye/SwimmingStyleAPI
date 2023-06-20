using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwimmingStyleAPI.Models.SwimmingStyleDto;
using SwimmingStyleAPI.Services;

namespace SwimmingStyleAPI.Controllers
{
    [ApiController]
    [Route("api/swimmingStyle")] // [Route("[controller]")] or [Route("api/[controller]")] because of the name of the controller is SwimmingStyleController
    public class SwimmingStyleController : ControllerBase
    {
        // repository
        private readonly ISwimmingStyleRepository _swimmingStyleRepository;
        private readonly IMapper _mapper;

        public SwimmingStyleController(ISwimmingStyleRepository swimmingStyleRepository, IMapper mapper )
        {
            _swimmingStyleRepository = swimmingStyleRepository ?? throw new ArgumentNullException(nameof(swimmingStyleRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SwimmingStyleWithoutStatsOfSwimmingStyleDto>>> GetAllSwimmingStyle()
        {
            var swimmingStyleEntities = await _swimmingStyleRepository.GetAllSwimmingStylesAsync();

            return Ok(_mapper.Map<IEnumerable<SwimmingStyleWithoutStatsOfSwimmingStyleDto>>(swimmingStyleEntities));
        }

        // create to get by id
        [HttpGet("{SwimmingStyleId}")]
        public async Task<ActionResult<SwimmingStyleDto>> GetSwimmingStyleById(int swimmingStyleId)
        {
            //var swimmingStyleToReturn = await _swimmingStyleRepository.GetSwimmingStyleById(swimmingStyleId, true);
            //if (swimmingStyleToReturn == null)
            //{
            //    return NotFound();
            //}

            //return Ok(swimmingStyleToReturn);
            return Ok();
        }

        /*   [HttpPost]
           public ActionResult<SwimmingStyleDto> CreateSwimmingStyle( SwimmingStyleForCreation swimmingStyle)
           {
               // need to calculate the ide of the new item 
               var maxSwimmingStyleId = SwimmingStyleDataStore.Current.SwimmingStyles.Max(p => p.SwimmingStyleId);
               // need to mapping because we work with swimming style dto and i need to create swimming style dto
               var finalSwimmingStyle = new SwimmingStyleDto()
               {
                   SwimmingStyleId = ++maxSwimmingStyleId,
                   Name = swimmingStyle.Name,
                   Image = swimmingStyle.Image,
                   Tags = swimmingStyle.Tags,
                   Description = swimmingStyle.Description
               };
               SwimmingStyleDataStore.Current.SwimmingStyles.Add(finalSwimmingStyle);
               return CreatedAtAction(nameof(GetSwimmingStyleById),
                                  new { SwimmingStyleId = finalSwimmingStyle.SwimmingStyleId },
                                                 finalSwimmingStyle);
           }*/
    }
}
