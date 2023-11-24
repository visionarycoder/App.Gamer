using Gamer.Resources.Data.GamerDb.Models;

namespace Gamer.Components.Accessors.Players;

public interface IPlayersAccess
{
	Task<GamePlayer> GetPlayer(int id);
	Task<ICollection<GamePlayer>> FindPlayers(PlayerFilter filter);
	Task<GamePlayer> AddPlayer(GamePlayer player);
	Task<GamePlayer> UpdatePlayer(GamePlayer player);
}

public class PlayerFilter
{
	public bool FindAll { get; set; }
	public ICollection<int>? Ids { get; set; } = null;
	public int? GameSessionId { get; set; }
}