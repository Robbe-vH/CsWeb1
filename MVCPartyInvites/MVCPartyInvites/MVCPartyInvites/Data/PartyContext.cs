using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCPartyInvites.Models;

namespace MVCPartyInvites.Data
{
    public class PartyContext : IdentityDbContext
    {
        public PartyContext(DbContextOptions<PartyContext> options) : base(options)
        {
        }

        public DbSet<Gast>? Gasten { get; set; }
    }
}