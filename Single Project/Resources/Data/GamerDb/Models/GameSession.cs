namespace Gamer.Resources.Data.GamerDb.Models;

public class GameSession
{
	private static int id;
	public int Id { get; init; } = id++;
	public int GameDefinitionId { get; set; }
	public virtual GameDefinition GameDefinition { get; set; } = null!;
	public virtual ICollection<GamePlayer> GamePlayers { get; } = new List<GamePlayer>();
	public virtual ICollection<GameCell> GameCells { get; } = new List<GameCell>();
}