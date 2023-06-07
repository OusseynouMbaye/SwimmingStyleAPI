using SQLitePCL;
using SwimmingStyleAPI.Models.StatsDto;
using SwimmingStyleAPI.Models.SwimmingStyleDto;

namespace SwimmingStyleAPI
{
    public class SwimmingStyleDataStore
    {
        public List<SwimmingStyleDto> SwimmingStyles { get; set; }

        // add static property
        public static SwimmingStyleDataStore Current { get; } = new SwimmingStyleDataStore();


        readonly string[] tagsFree = { "crawl", "freestyle", "front crawl" };
        readonly string[] tagsFly = { "butterfly", "fly" };
        public SwimmingStyleDataStore()
        {

            SwimmingStyles = new List<SwimmingStyleDto>()
            {
                new SwimmingStyleDto()
                {
                    SwimmingStyleId = 1,
                    Name = "Name",
                    Image = "freeStyle",
                    Tags= tagsFree,
                    Description= "The front crawl or forward crawl, also known as the Australi",
                    // add dummy data for stats
                    StatsOfSwimmingStyle = new List<StatsSwimmingstyleDto>()
                    {
                        new StatsSwimmingstyleDto()
                        {
                            IdStats = 1,
                            Speed = 4,
                            Endurance = 4,
                            Technique = 2,
                            Difficulty = 3,
                        },
                        new StatsSwimmingstyleDto()
                        {
                            IdStats = 2,
                            Speed = 5,
                            Endurance = 5,
                            Technique = 5,
                            Difficulty = 5,
                        },
                    }

                },
                new SwimmingStyleDto()
                {
                    SwimmingStyleId = 2,
                    Name = "Butterfly",
                    Image = "Butterfly",
                    Tags = tagsFly,
                    Description ="Butterfly is so hard",
                    // add dummy data for stats
                    StatsOfSwimmingStyle = new List<StatsSwimmingstyleDto>()
                    {
                        new StatsSwimmingstyleDto()
                        {
                            IdStats = 1,
                            Speed = 5,
                            Endurance = 5,
                            Technique = 5,
                            Difficulty = 5,
                        },
                        new StatsSwimmingstyleDto()
                        {
                            IdStats = 2,
                            Speed = 2,
                            Technique = 3,
                            Endurance = 3,
                            Difficulty = 4,
                        }
                    }
                }
            };
        }
    }
}
