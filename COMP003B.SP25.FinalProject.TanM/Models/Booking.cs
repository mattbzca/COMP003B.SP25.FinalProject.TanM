using System.ComponentModel.DataAnnotations;
namespace COMP003B.SP25.FinalProject.TanM.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        [StringLength(200)]
        public string ResidencyAddress { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate{ get; set; }

        [Required]
        [StringLength(15)]
        public string BookStatus { get; set; }

        // Collection navigation property
        public virtual ICollection<Itinerary>? Itinerarys { get; set; }
    }
}
