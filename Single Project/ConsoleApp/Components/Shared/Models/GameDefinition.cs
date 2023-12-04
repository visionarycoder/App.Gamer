using Gamer.Framework;

namespace Gamer.Components.Shared.Models;

public sealed class GameDefinition : BusinessObject
{
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string TurnPrompt { get; init; } = string.Empty;
    public int NumberOfPlayers { get; init; } = 2;
    public bool IsTurnBased { get; init; } = true;
    public bool AllowOverwrite { get; init; } = true;
    public BoardDefinition BoardDefinition { get; set; } = null!;


}