using System.ComponentModel.DataAnnotations;

namespace SwimmingStyleAPI.Models.SwimmingStyleDto
{
    public class SwimmingStyleForCreation
    {
        //public int SwimmingStyleId { get; set; }
        [Required(ErrorMessage = "we need to add a name")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string? Image { get; set; }

        [Required (ErrorMessage = "The Image fied is required") ]
        [MaxLength(150)]
        public string[]? Tags { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Description { get; set; }


    }
}
