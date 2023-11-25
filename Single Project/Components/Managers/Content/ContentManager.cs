using Gamer.Components.Accessors.Games;
using Gamer.Components.Accessors.Players;
using Gamer.Framework;

using Microsoft.Extensions.Logging;

namespace Gamer.Components.Managers.Content;

public class ContentManager : ServiceObject<ContentManager>, IContentManager
{

	private readonly IGamesAccess gameAccess;
	private readonly IPlayersAccess playersAccess;

	public ContentManager(ILogger logger, IGamesAccess gameAccess, IPlayersAccess playersAccess)
		: base(logger)
	{
		this.gameAccess = gameAccess;
		this.playersAccess = playersAccess;
	}

}