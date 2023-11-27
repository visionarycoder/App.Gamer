using Gamer.Resources.Data.GamerDb.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RulesEngine.Models;

using System.Reflection.Emit;
using System.Text.Json;

namespace Gamer.Resources.Data.GamerDb;

public class GamerContext : DbContext
{

	private readonly JsonSerializerOptions serializationOptions = new (JsonSerializerDefaults.General);
	private readonly ValueComparer<Dictionary<string,object>> valueComparer = new (
		(dictionary, objects) => dictionary!.SequenceEqual(objects!),
		dictionary => dictionary.Aggregate(0, (i, keyValuePair) => HashCode.Combine(i, keyValuePair.GetHashCode())),
		dictionary => dictionary);

	public Guid InstanceId { get; }= Guid.NewGuid();


	public DbSet<GameDefinition> GameDefinitions { get; set; } = null!;
	public DbSet<GameCell> GameCells { get; set; } = null!;
	
	public DbSet<GamePlayer> GamePlayers { get; set; } = null!;
	public DbSet<GameSession> GameSessions { get; set; } = null!;
	
	public DbSet<Rule> Rules { get; set; } = null!;
	public DbSet<Workflow> Workflows { get; set; } = null!;

	public GamerContext(DbContextOptions<GamerContext> options)
		: base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		ArgumentNullException.ThrowIfNull(modelBuilder, nameof(modelBuilder));
		OnModelCreating(modelBuilder.Entity<GameDefinition>());
		OnModelCreating(modelBuilder.Entity<GameCell>());
		OnModelCreating(modelBuilder.Entity<GamePlayer>());
		OnModelCreating(modelBuilder.Entity<GameSession>());
		OnModelCreating(modelBuilder.Entity<Rule>());
		OnModelCreating(modelBuilder.Entity<Workflow>());
		base.OnModelCreating(modelBuilder);
	}

	private void OnModelCreating(EntityTypeBuilder<GameDefinition> entity)
	{
		ArgumentNullException.ThrowIfNull(entity, nameof(entity));
		entity.ToTable(nameof(GameDefinitions));
		entity.Property(e => e.Id).ValueGeneratedOnAdd();
		entity.HasKey(e => e.Id).IsClustered();
		entity.HasMany(e => e.GameSessions).WithOne(e => e.GameDefinition).HasForeignKey(e => e.GameDefinitionId);
	}

	private void OnModelCreating(EntityTypeBuilder<GameCell> entity)
	{
		ArgumentNullException.ThrowIfNull(entity, nameof(entity));
		entity.ToTable(nameof(GameCell));
		entity.Property(e => e.Id).ValueGeneratedOnAdd();
		entity.HasKey(e => e.Id).IsClustered();
		entity.HasOne(e => e.GamePlayer).WithMany().HasForeignKey(e => e.GamePlayerId);
		entity.HasOne(e => e.GameSession).WithMany().HasForeignKey(e => e.GameSessionId);
	}
	
	private void OnModelCreating(EntityTypeBuilder<GamePlayer> entity)
	{
		ArgumentNullException.ThrowIfNull(entity, nameof(entity));
		entity.ToTable(nameof(GamePlayer));
		entity.Property(e => e.Id).ValueGeneratedOnAdd();
		entity.HasKey(e => e.Id).IsClustered();
	}

	private void OnModelCreating(EntityTypeBuilder<GameSession> entity)
	{
		ArgumentNullException.ThrowIfNull(entity, nameof(entity));
		entity.ToTable(nameof(GameSession));
		entity.Property(e => e.Id).ValueGeneratedOnAdd();
		entity.HasKey(e => e.Id).IsClustered();
		entity.HasOne(e => e.GameDefinition).WithMany().HasForeignKey(e => e.GameDefinitionId);
		entity.HasMany(e => e.GamePlayers).WithMany(e => e.GameSessions);
	}

	private void OnModelCreating(EntityTypeBuilder<Workflow> entity)
	{
		ArgumentNullException.ThrowIfNull(entity, nameof(entity));
		entity.ToTable(nameof(Workflow));
		entity.HasKey(e => e.WorkflowName);
		entity.Ignore(e => e.WorkflowsToInject);
	}

	private void OnModelCreating(EntityTypeBuilder<Rule> entity)
	{
		ArgumentNullException.ThrowIfNull(entity, nameof(entity));
		entity.ToTable(nameof(Rule));
		entity.HasKey(e => e.RuleName);
		entity.Ignore(e => e.WorkflowsToInject);
		entity.HasOne<Rule>().WithMany(e => e.Rules).HasForeignKey(e => e.RuleName);

		entity
			.Property(e => e.Properties)
			.HasConversion(
			value => JsonSerializer.Serialize(value, serializationOptions),
			str => JsonSerializer.Deserialize<Dictionary<string, object>>(str, serializationOptions)!
			)
			.Metadata
			.SetValueComparer(valueComparer);
		entity
			.Property(e => e.Actions)
			.HasConversion(
				value => JsonSerializer.Serialize(value, serializationOptions), 
				str => JsonSerializer.Deserialize<RuleActions>(str, serializationOptions)!
			);
	}

}