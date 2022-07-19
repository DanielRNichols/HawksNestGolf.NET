using HawksNestGolf.NET.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HawksNestGolf.NET.Server.DbContexts
{
    public class HawksNestGolfDbContext : DbContext
    {
        public HawksNestGolfDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
    }
}
