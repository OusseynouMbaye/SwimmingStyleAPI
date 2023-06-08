﻿using Microsoft.AspNetCore.Mvc;
using SwimmingStyleAPI.Models.StatsDto;
using SwimmingStyleAPI.Models.SwimmingStyleDto;
using System.Net.NetworkInformation;

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

        [HttpGet("{StatsId}", Name = "GetSwimmingStyleById")]
        public ActionResult<StatsSwimmingstyleDto> GetSwimmingStyleById(int SwimmingStyleId, int StatsId)
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



    }
}
