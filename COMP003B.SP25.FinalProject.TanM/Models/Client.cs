using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.TanM.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        // Collection navigation property
        public virtual ICollection<Itinerary>? Itinerarys { get; set; }

        public string HomeAddress { get; set; } // New property added
    }
}
