using Microsoft.EntityFrameworkCore;
using Hotel.WebAPI;
using Hotel.WebAPI.Entities;

namespace Hotel.WebAPI.Infrastructure.Database
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        { 
        
        }

        // ovdje dodati DbSet-ove za entitete
        public DbSet<Entities.Hotel> Hotels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
