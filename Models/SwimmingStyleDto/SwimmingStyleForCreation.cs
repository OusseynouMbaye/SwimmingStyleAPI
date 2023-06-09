using System.ComponentModel.DataAnnotations;

namespace SwimmingStyleAPI.Models.SwimmingStyleDto
{
    public class SwimmingStyleForCreation
    {
        //public int SwimmingStyleId { get; set; }
    
        public string Name { get; set; } = string.Empty; 
        public string? Image { get; set; }
        public string[]? Tags { get; set; } 
        public string? Description { get; set; }


    }
}
