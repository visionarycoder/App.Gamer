using Gamer.Framework;
using Gamer.Resources.Data.GamerDb;
using Gamer.Resources.Data.GamerDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Gamer.Components.Accessors.Players;

public class PlayersAccess : ServiceObject<PlayersAccess>, IPlayersAccess
{

	private readonly GamerContext ctx;

	public PlayersAccess(ILogger logger, DbContextOptions<GamerContext> options) 
		: base(logger)
	{
		ctx = new GamerContext(options);
	}

	public async Task<GamePlayer> GetPlayer(int id)
	{
		throw new NotImplementedException();
	}

	public async Task<ICollection<GamePlayer>> FindPlayers(PlayerFilter filter)
	{
		throw new NotImplementedException();
	}

	public async Task<GamePlayer> AddPlayer(GamePlayer player)
	{
		throw new NotImplementedException();
	}

	public async Task<GamePlayer> UpdatePlayer(GamePlayer player)
	{
		throw new NotImplementedException();
	}
}