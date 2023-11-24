using System.Diagnostics;
using Gamer.Resources.Data.GamerDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamer.Resources.Data.GamerDb;

public class GamerContext : DbContext
{

	DbSet<GameDefinition> GameDefinitions { get; set; }
	DbSet<GamePlayer> GamePlayers { get; set; }
	DbSet<GamePlayerType> GamePlayerTypes { get; set; }
	DbSet<GameRule> GameRules { get; set; }
	DbSet<GameSession> GameSessions { get; set; }
	DbSet<GameSessionPlayer> GameSessionPlayers { get; set; }
	DbSet<GameType> GameTypes { get; set; }
	DbSet<GameWorkflow> GameWorkflows { get; set; }

	public GamerContext(DbContextOptions<GamerContext> options)
		: base(options)
	{

		Database.EnsureCreated();

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		Debug.Assert(modelBuilder != null, nameof(modelBuilder) + " != null");

		OnModelCreating(modelBuilder.Entity<GameDefinition>());
		OnModelCreating(modelBuilder.Entity<GamePlayer>());
		OnModelCreating(modelBuilder.Entity<GamePlayerType>());
		OnModelCreating(modelBuilder.Entity<GameRule>());
		OnModelCreating(modelBuilder.Entity<GameSession>());
		OnModelCreating(modelBuilder.Entity<GameSessionPlayer>());
		OnModelCreating(modelBuilder.Entity<GameType>());
		OnModelCreating(modelBuilder.Entity<GameWorkflow>());

		base.OnModelCreating(modelBuilder);

	}

	private void OnModelCreating(EntityTypeBuilder<GameDefinition> entity)
	{
		entity.ToTable(nameof(GameDefinitions));
		entity.HasIndex(e => e.Id).IsUnique();
		entity.Property(e => e.Id).ValueGeneratedOnAdd();
		entity.Property(e => e.Name).IsRequired();
		entity.Property(e => e.Description).IsRequired();
		entity.Property(e => e.GameTypeId).IsRequired();

	}

	private void OnModelCreating(EntityTypeBuilder<GamePlayer> entity)
	{
		entity.ToTable(nameof(GamePlayers));
		entity.HasIndex(e => e.Id).IsUnique();
		entity.Property(e => e.Id).ValueGeneratedOnAdd();
	}

	private void OnModelCreating(EntityTypeBuilder<GamePlayerType> entity)
	{
		entity.ToTable(nameof(GamePlayerTypes));
		entity.HasIndex(e => e.Id).IsUnique();
		entity.Property(e => e.Id).ValueGeneratedOnAdd();
	}

	private void OnModelCreating(EntityTypeBuilder<GameRule> entity)
	{
		entity.ToTable(nameof(GameRule));
		entity.HasIndex(e => e.Id).IsUnique();
		entity.Property(e => e.Id).ValueGeneratedOnAdd();
	}

	private void OnModelCreating(EntityTypeBuilder<GameSession> entity)
	{
		entity.ToTable(nameof(GameSessions));
		entity.HasIndex(e => e.Id).IsUnique();
		entity.Property(e => e.Id).ValueGeneratedOnAdd();
	}

	private void OnModelCreating(EntityTypeBuilder<GameSessionPlayer> entity)
	{
		entity.ToTable(nameof(GameSessionPlayers));
		entity.HasIndex(e => e.Id).IsUnique();
		entity.Property(e => e.Id).ValueGeneratedOnAdd();
	}

	private void OnModelCreating(EntityTypeBuilder<GameType> entity)
	{
		entity.ToTable(nameof(GameTypes));
		entity.HasIndex(e => e.Id).IsUnique();
		entity.Property(e => e.Id).ValueGeneratedOnAdd();
		entity.Property(e => e.Name).IsRequired();
	}

	private void OnModelCreating(EntityTypeBuilder<GameWorkflow> entity)
	{
		entity.ToTable(nameof(GameWorkflow));
		entity.HasIndex(e => e.Id).IsUnique();
		entity.Property(e => e.Id).ValueGeneratedOnAdd();
	}

}

