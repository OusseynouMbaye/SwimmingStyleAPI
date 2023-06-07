using SwimmingStyleAPI.Models.StatsDto;

namespace SwimmingStyleAPI.Models.SwimmingStyleDto
{
    public class SwimmingStyleDto
    {
        public int SwimmingStyleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string[]? Tags { get; set; }
        public string? Description { get; set; }

        // Number of times the swimming style has been used
        public int NumberOfTimesUsed
        {
            get
            {
                return StatsOfSwimmingStyle.Count;
            }
        }

        // set collection navigation property 
        public ICollection<StatsSwimmingstyleDto> StatsOfSwimmingStyle { get; set; } = new List<StatsSwimmingstyleDto>();

    }
}
