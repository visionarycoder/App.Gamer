using Gamer.Components.Accessors.Games;
using Gamer.Components.Accessors.Players;
using Gamer.Framework;
using Microsoft.Extensions.Logging;

namespace Gamer.Components.Managers.Admin;

public class AdminManager : ServiceObject<AdminManager>, IAdminManager
{

	private readonly IGamesAccess gameAccess;
	private readonly IPlayersAccess playersAccess;

	public AdminManager(ILogger logger, IGamesAccess gameAccess, IPlayersAccess playersAccess) 
		: base(logger)
	{
		this.gameAccess = gameAccess;
		this.playersAccess = playersAccess;
	}

}