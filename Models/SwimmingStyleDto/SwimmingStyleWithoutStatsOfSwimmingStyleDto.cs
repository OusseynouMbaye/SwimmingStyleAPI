namespace SwimmingStyleAPI.Models.SwimmingStyleDto
{
    public class SwimmingStyleWithoutStatsOfSwimmingStyleDto
    {
        public int SwimmingStyleId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; }
        //public string? Tags { get; set; }
    }
}
