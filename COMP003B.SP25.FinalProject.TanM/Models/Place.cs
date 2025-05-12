using System.ComponentModel.DataAnnotations;
namespace COMP003B.SP25.FinalProject.TanM.Models
{
    public class Place
    {
        public int PlaceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [Range(0,5)]
        public int TerrainDifficulty { get; set; }


        // Collection navigation property
        public virtual ICollection<Itinerary>? Itinerarys { get; set; }
    }
}
