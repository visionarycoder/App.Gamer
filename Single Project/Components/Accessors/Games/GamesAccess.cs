using Gamer.Framework;
using Gamer.Resources.Data.GamerDb;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Gamer.Components.Accessors.Games;

public class GamesAccess : ServiceObject<GamesAccess>, IGamesAccess
{

	private readonly GamerContext ctx;

	public GamesAccess(ILogger logger, DbContextOptions<GamerContext> options)
		: base(logger)
	{
		ctx = new GamerContext(options);
	}

}