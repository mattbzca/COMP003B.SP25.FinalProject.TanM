using System.ComponentModel.DataAnnotations;
namespace COMP003B.SP25.FinalProject.TanM.Models
{
    public class Fee
    {
        public int FeeId { get; set; }

        [Required]
        public decimal TotalDue { get; set; }

        [Required]
        [StringLength(200)]
        public string PaymentReason { get; set; }

        [Required]
        public DateTime DateIssued { get; set; }

        [Required]
        public bool PremiumMembership { get; set; }

        // Collection navigation property
        public virtual ICollection<Itinerary>? Itinerarys { get; set; }
    }
}
