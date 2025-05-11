using System.ComponentModel.DataAnnotations;
namespace COMP003B.SP25.FinalProject.TanM.Models
{
    public class Itinerary
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PlaceId { get; set; }
    }
}
