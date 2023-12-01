using Gamer.Framework;

namespace Gamer.Components.Shared.Models;

public sealed class GameCell : BusinessObject
{
	public GameSession GameSession { get; set; } = null!;
    public BoardPosition BoardPosition { get; set; } = null!;
    public string Token { get; set; } = string.Empty;
}