//using Hotel.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;


namespace Hotel.WebAPI.Infrastructure.Database
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        { 
        
        }

        // ovdje dodati DbSet-ove za entitete
        // public DbSet<Entity> Entities {get; set;}
    }
}
