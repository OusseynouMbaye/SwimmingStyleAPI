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

        public SwimmingStyleController(ISwimmingStyleRepository swimmingStyleRepository)
        {
            _swimmingStyleRepository = swimmingStyleRepository ?? throw new ArgumentNullException(nameof(swimmingStyleRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SwimmingStyleWithoutStatsOfSwimmingStyleDto>>> GetAllSwimmingStyle()
        {
            var swimmingStyleEntities = await _swimmingStyleRepository.GetAllSwimmingStylesAsync();

            var result = new List<SwimmingStyleWithoutStatsOfSwimmingStyleDto>();
            foreach (var swimmingStyleEntitie in swimmingStyleEntities)
            {
                result.Add(new SwimmingStyleWithoutStatsOfSwimmingStyleDto
                {
                    SwimmingStyleId = swimmingStyleEntitie.Id,
                    Name = swimmingStyleEntitie.Name,
                    Description = swimmingStyleEntitie.Description,


                });
            }

            return Ok(result);
        }

        // create to get by id
        [HttpGet("{SwimmingStyleId}")]
        public async Task<ActionResult<SwimmingStyleDto>> GetSwimmingStyleById(int SwimmingStyleId)
        {
            //var swimmingStyleToReturn = await _swimmingStyleRepository.GetSwimmingStyleById();
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
