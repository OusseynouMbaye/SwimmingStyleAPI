using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwimmingStyleAPI.Entitites
{
    public class SwimmingStyleEntities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // 
        public int Id { get; set; }
        public string Name { get; set; } // not null by default for avoid default constructor has generate
        public string? Image { get; set; }
        public string? Description { get; set; }
        //public string[]? Tags { get; set; }

        public ICollection<StatsSwimmingstyleEntities> StatsOfSwimmingStyle { get; set; } 
            = new List<StatsSwimmingstyleEntities>();

        public SwimmingStyleEntities(string name ) 
        { 
            Name = name;
        }
    }
}
