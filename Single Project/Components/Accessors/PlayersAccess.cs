using Gamer.Components.Accessors.Extensions;
using Gamer.Components.Accessors.Models;
using Gamer.Framework;
using Gamer.Framework.Enums;
using Gamer.Resources.Data.GamerDb;
using Gamer.Resources.Data.GamerDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Gamer.Components.Accessors;

public class PlayersAccess : ServiceObject<PlayersAccess>
{

	private readonly GamerContext ctx;
	private readonly string unknown = Enum.GetName(typeof(PlayerType), PlayerType.Unknown) ?? "Unknown";

	public PlayersAccess(ILogger logger, DbContextOptions<GamerContext> options)
			: base(logger)
	{
		ctx = new GamerContext(options);
	}

	public async Task<Player?> GetAsync(int id)
	{

		var data = await ctx.GamePlayers.SingleOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
		if (data is null)
		{
			return null;
		}
		var dto = data.Convert();
		return dto;

	}

	public async Task<ICollection<Player>> ListAsync()
	{
		var data = await ctx.GamePlayers.ToListAsync().ConfigureAwait(false);
		var dtos = data.Select(x => x.Convert()).ToList();
		return dtos;
	}

	public async Task<Player> AddAsync(Player player)
	{
		var gamePlayer = new GamePlayer
		{
			PlayerType = Enum.GetName(typeof(PlayerType), player.PlayerType) ?? unknown,
			Name = player.Name,
			Token = player.Token
		};

		await ctx.AddAsync(gamePlayer).ConfigureAwait(false);
		await ctx.SaveChangesAsync().ConfigureAwait(false);
		return await GetAsync(gamePlayer.Id).ConfigureAwait(false) ?? throw new Exception("Failed to add player");
	}

	public async Task<bool> UpdateAsync(Player player)
	{
		var dbObject = await ctx.GamePlayers.SingleOrDefaultAsync(x => x.Id == player.Id).ConfigureAwait(false);
		if (dbObject is null)
		{
			return false;
		}
		// ToDo: Update the dbObject with the player data
		var count = await ctx.SaveChangesAsync().ConfigureAwait(false);
		return count == 1;
	}

	public async Task<bool> DeleteAsync(Player player)
	{
		var data = await ctx.GamePlayers.SingleOrDefaultAsync(x => x.Id == player.Id).ConfigureAwait(false);
		if (data is null)
		{
			logger.LogWarning($"Failed to delete player {player.Id}.  Entry not found.");
			return false;
		}
		ctx.GamePlayers.Remove(data);
		var count = await ctx.SaveChangesAsync().ConfigureAwait(false);
		return count == 1;
	}

}