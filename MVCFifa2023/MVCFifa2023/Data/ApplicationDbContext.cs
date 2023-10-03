using Microsoft.EntityFrameworkCore;
using MVCFifa2023.Models;

namespace MVCFifa2023.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Player> Players { get; set; }
    }
}
