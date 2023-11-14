using Microsoft.EntityFrameworkCore;
using PXLHotel_12200496.Models;

namespace PXLHotel_12200496.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
    }
}
