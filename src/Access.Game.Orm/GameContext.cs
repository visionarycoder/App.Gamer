using Access.Game.Orm.Models;
using Microsoft.EntityFrameworkCore;

namespace Access.Game.Orm
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        public DbSet<GameDefinition> GameDefinitions { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure GameDefinition entity
            modelBuilder.Entity<GameDefinition>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ReleaseDate).IsRequired();
                entity.Property(e => e.Genre).HasMaxLength(50);
                entity.Property(e => e.Developer).HasMaxLength(100);
                // Other configurations
            });

            // Configure GameSession entity
            modelBuilder.Entity<GameSession>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.GameId).IsRequired();
                entity.Property(e => e.StartTime).IsRequired();
                entity.Property(e => e.Player).IsRequired().HasMaxLength(100);
                entity.HasOne(e => e.Game)
                      .WithMany()
                      .HasForeignKey(e => e.GameId);
                // Other configurations
            });
        }
    }
}
