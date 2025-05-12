using COMP003B.SP25.FinalProject.TanM.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.SP25.FinalProject.TanM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Itinerary> Itinerarys { get; set; }
    }
}
