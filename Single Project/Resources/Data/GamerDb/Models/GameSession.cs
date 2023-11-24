namespace Gamer.Resources.Data.GamerDb.Models;

public class GameSession
{

	public int Id { get; set; }
	public int GameDefinitionId { get; set; }
	
	public virtual ICollection<GamePlayer> GamePlayers { get; } = new List<GamePlayer>();


}