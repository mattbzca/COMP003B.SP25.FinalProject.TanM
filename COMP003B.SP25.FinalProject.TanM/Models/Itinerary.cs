using System.ComponentModel.DataAnnotations;
namespace COMP003B.SP25.FinalProject.TanM.Models
{
    public class Itinerary
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PlaceId { get; set; }
        public int FeeId { get; set; }
        public int BookId { get; set; }

        //Nullable navigation properties
        public virtual Client? Client { get; set; }
        public virtual Place? Place { get; set; }
        public virtual Fee? Fee { get; set; }
        public virtual Booking? Booking { get; set; }
    }
}
