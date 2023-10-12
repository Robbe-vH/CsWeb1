using Microsoft.EntityFrameworkCore;
using WebAppMVCCliebtLocationEFCore.Models;

namespace WebAppMVCCliebtLocationEFCore.Data
{
    public class ClientLocationContext : DbContext
    {
        public ClientLocationContext(DbContextOptions<ClientLocationContext> options) : base(options)
        {
        }
        public DbSet<Location>? Locations { get; set; }
        public DbSet<Client>? Clients { get; set; }
        public DbSet<WebAppMVCCliebtLocationEFCore.Models.Product>? Product { get; set; }

    }
}
