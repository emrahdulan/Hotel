using Microsoft.EntityFrameworkCore;
using Hotel.WebAPI;


namespace Hotel.WebAPI.Infrastructure.Database
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {

        }

        // ovdje dodati DbSet-ove za entitete
        public DbSet<Entities.Hotel> Hotels { get; set; }
        public DbSet<Entities.Room> Roms { get; set; }
        public DbSet<Entities.Employee> Employees { get; set; }
    }
    
}
