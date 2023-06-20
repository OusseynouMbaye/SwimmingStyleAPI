namespace SwimmingStyleAPI.Models.SwimmingStyleDto
{
    public class SwimmingStyleWithoutStatsOfSwimmingStyleDto
    {
        public int Id { get; set; } // not SwimmingStyleId
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; }
        //public string[]? Tags { get; set; } 
    }
}
