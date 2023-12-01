using Gamer.Framework;

namespace Gamer.Components.Shared.Models;

public sealed class GameDefinition : BusinessObject
{
	public string Name { get; init; } = string.Empty;
	public string Description { get; init; } = string.Empty;
	public string TurnPrompt { get; init; } = string.Empty;
	public int MaxNumberOfPlayers { get; init; }
	public int MinNumberOfPlayers { get; init; }
	public BoardDefinition BoardDefinition { get; init; } = null!;
}