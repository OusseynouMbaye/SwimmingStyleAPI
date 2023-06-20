using System.ComponentModel.DataAnnotations.Schema;

namespace SwimmingStyleAPI.Entitites
{
    public class StatsSwimmingstyleEntities
    {
        public int Id { get; set; }
        public int Speed { get; set; }
        public int Endurance { get; set; }
        public int? Technique { get; set; }
        public int? Difficulty { get; set; }

        // fk to SwimmingStyleEntities 
        [ForeignKey("SwimmingStyleEntitiesId")]
        public SwimmingStyleEntities? SwimmingStyleEntitie { get; set; } // navigation property Fk to SwimmingStyleEntities 
        public int SwimmingStyleEntitiesId { get; set; } // Fk to SwimmingStyleEntities

        public StatsSwimmingstyleEntities(int speed)
        {
            Speed = speed;
        }
    }
}