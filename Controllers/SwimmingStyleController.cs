using Microsoft.AspNetCore.Mvc;
using SwimmingStyleAPI.Models;

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
        public ActionResult<SwimmingStyleDto> GetswimmingstyleById(int SwimmingStyleId)
        {
            var swimmingStyleToReturn = SwimmingStyleDataStore.Current.SwimmingStyles
                  .Find(x => x.SwimmingStyleId == SwimmingStyleId);
            if (swimmingStyleToReturn == null)
            {
                return NotFound();
            }

            return Ok(swimmingStyleToReturn);
        }

        /*// create to post
        [HttpPost]
        public SwimmingStyleDto PostSwimmingStyle(SwimmingStyleDto swimmingStyle)
        {
            return swimmingStyle;
        }

        // create to put
        [HttpPut("{SwimmingStyleId}")]
        public SwimmingStyleDto PutSwimmingStyle(int SwimmingStyleId, SwimmingStyleDto swimmingStyle)
        {
            return swimmingStyle;
        }

        // create to patch
        [HttpPatch("{SwimmingStyleId}")]
        public SwimmingStyleDto PatchSwimmingStyle(int SwimmingStyleId, SwimmingStyleDto swimmingStyle)
        {
            return swimmingStyle;
        }*/

    }
}
