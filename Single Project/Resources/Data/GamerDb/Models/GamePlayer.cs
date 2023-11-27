namespace Gamer.Resources.Data.GamerDb.Models;

public class GamePlayer
{
	private static int id;
	public int Id { get; init; } = id++;
	public string Name { get; set; } = string.Empty;
	public string PlayerType { get; set; } = string.Empty;
	public string Token { get; set; } = string.Empty;
	public virtual ICollection<GameSession> GameSessions { get; } = new List<GameSession>();
}