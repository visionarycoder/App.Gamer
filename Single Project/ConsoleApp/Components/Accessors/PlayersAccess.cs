using Gamer.Components.Accessors.Helpers;
using Gamer.Components.Shared.Enums;
using Gamer.Components.Shared.Models;
using Gamer.Framework;

namespace Gamer.Components.Accessors;

public class PlayersAccess : ServiceObject<PlayersAccess>
{

	private readonly HashSet<GamePlayer> data = new();

	public GamePlayer? Get(int id)
	{
        return data.SingleOrDefault(s => s.Id == id);
	}

	public ICollection<GamePlayer> List()
    {
        return data.OrderBy(x => x.Name).ToList();
    }

	public GamePlayer Create(string name, string token, PlayerType playerType)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        ArgumentException.ThrowIfNullOrWhiteSpace(token, nameof(token));
		var player = GamePlayerFactory.Create(name, token, playerType);
		data.Add(player);
        return player;
    }

    public bool Update(GamePlayer gamePlayer)
	{
        ArgumentNullException.ThrowIfNull(gamePlayer, nameof(gamePlayer));
        var existing = data.SingleOrDefault(x => x.Id == gamePlayer.Id);
        if (existing is null)
        {
            return false;
        }
		existing.Name = gamePlayer.Name;
		existing.PlayerType = gamePlayer.PlayerType;
		existing.Token = gamePlayer.Token;
		existing.GameSessions = gamePlayer.GameSessions;
		return true;
	}

	public bool Delete(GamePlayer gamePlayer)
	{
        var existing = data.SingleOrDefault(x => x.Id == gamePlayer.Id);
        if (existing is null)
        {
            return false;
        }
        data.Remove(existing);
        return true;
    }

}