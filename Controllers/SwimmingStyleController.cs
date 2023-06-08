using Microsoft.AspNetCore.Mvc;
using SwimmingStyleAPI.Models.SwimmingStyleDto;

namespace SwimmingStyleAPI.Controllers
{
    [ApiController]
    [Route("api/swimmingStyle")] // [Route("[controller]")] or [Route("api/[controller]")] because of the name of the controller is SwimmingStyleController
    public class SwimmingStyleController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<SwimmingStyleDto>> GetAllSwimmingStyle()
        {
            var swimmingStyleToReturn = SwimmingStyleDataStore.Current.SwimmingStyles;
            return Ok(swimmingStyleToReturn);
        }

        // create to get by id
        [HttpGet("{SwimmingStyleId}")]
        public ActionResult<SwimmingStyleDto> GetSwimmingStyleById(int SwimmingStyleId)
        {
            var swimmingStyleToReturn = SwimmingStyleDataStore.Current.SwimmingStyles
                  .FirstOrDefault(x => x.SwimmingStyleId == SwimmingStyleId);
            if (swimmingStyleToReturn == null)
            {
                return NotFound();
            }

            return Ok(swimmingStyleToReturn);
        }

        [HttpPost]
        public ActionResult<SwimmingStyleDto> CreateSwimmingStyle([FromBody] SwimmingStyleForCreation swimmingStyle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
        }
    }
}
