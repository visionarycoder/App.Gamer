using Gamer.Components.Shared.Enums;
using Gamer.Framework;

namespace Gamer.Components.Shared.Models;

public sealed class GameSession : BusinessObject
{
	public int? CurrentPlayerId { get; set; }
	public GamePlayer? CurrentPlayer => Players.SingleOrDefault(p => p.Id == CurrentPlayerId)!;	
	public GameStatus GameStatus { get; set; }
	public GameDefinition GameDefinition { get; set; } = null!;
	public ICollection<GamePlayer> Players { get; set; } = new List<GamePlayer>();
	public ICollection<GameCell> Cells { get; set; } = new List<GameCell>();
	public DateTime Created { get; init; } = DateTime.UtcNow;
	public DateTime? Updated { get; set; }
	public ICollection<GameTurn> GameTurns { get; } = new List<GameTurn>();

}