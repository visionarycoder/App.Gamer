namespace Gamer.Resources.Data.GamerDb.Models;

public class GamePlayer
{

	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public int GamePlayerTypeId { get; set; }
	
	public virtual ICollection<GameSession> GameSessions { get; } = new List<GameSession>();

}