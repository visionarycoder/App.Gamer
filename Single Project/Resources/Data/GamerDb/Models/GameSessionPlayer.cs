namespace Gamer.Resources.Data.GamerDb.Models;

public class GameSessionPlayer
{

	public int Id { get; set; }
	
	public int GamePlayerId { get; set; }
	public virtual GamePlayer GamePlayer { get; set; } = null!;

	public int GameSessionId { get; set; }
	public virtual GameSession GameSession { get; set; } = null!;

}