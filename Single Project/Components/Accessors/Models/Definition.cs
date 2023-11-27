using Gamer.Framework.Enums;
using Gamer.Resources.Data.GamerDb.Models;
using RulesEngine.Models;

namespace Gamer.Components.Accessors.Models;

public class Definition
{

	public int Id { get; init; }
	
	public string Name { get; init; } = string.Empty;
	public string Description { get; init; } = string.Empty;
	
	public GameType GameType { get; init; }

	public int MaxNumberOfPlayers { get; init; }
	public int MinNumberOfPlayers { get; init; }

	public ICollection<Workflow> Workflows { get; init; } = new List<Workflow>();

}

