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
        public DbSet<Player> Players { get; set; }
        public DbSet<Golfer> Golfers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Player);
            //.WithMany(p => p.Messages)
            //.HasForeignKey(m => m.PlayerId);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Tournament);
        }

    }
}
