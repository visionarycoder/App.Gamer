using Gamer.Components.Accessors.Helpers;
using Gamer.Components.Shared.Enums;
using Gamer.Components.Shared.Models;
using Gamer.Framework;

namespace Gamer.Components.Accessors;

public class PlayersAccess : ServiceObject<PlayersAccess>
{

	private readonly HashSet<Player> data = new();

	public Player? Get(int id)
	{
        return data.SingleOrDefault(s => s.Id == id);
	}

	public ICollection<Player> List()
    {
        return data.OrderBy(x => x.Name).ToList();
    }

	public Player Create(string name, string token, PlayerType playerType)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        ArgumentException.ThrowIfNullOrWhiteSpace(token, nameof(token));
		var player = PlayerFactory.Create(name, token, playerType);
		data.Add(player);
        return player;
    }

    public bool Update(Player player)
	{
        ArgumentNullException.ThrowIfNull(player, nameof(player));
        var existing = data.SingleOrDefault(x => x.Id == player.Id);
        if (existing is null)
        {
            return false;
        }
		existing.Name = player.Name;
		existing.PlayerType = player.PlayerType;
		existing.Token = player.Token;
		existing.GameSessions = player.GameSessions;
		return true;
	}

	public bool Delete(Player player)
	{
        var existing = data.SingleOrDefault(x => x.Id == player.Id);
        if (existing is null)
        {
            return false;
        }
        data.Remove(existing);
        return true;
    }

}