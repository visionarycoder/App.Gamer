using Gamer.Components.Accessors.Models;

namespace Gamer.Resources.Data.GamerDb.Models;

public class GameCell
{

	private static int id;
	public int Id { get; init; } = id++;
	public int X { get; init; }
	public int Y { get; init; }

	public int GameSessionId { get; init; }
	public virtual GameSession GameSession { get; init; } = null!;
	
	public int? GamePlayerId { get; set; }
	public virtual Player? GamePlayer { get; set; }

}