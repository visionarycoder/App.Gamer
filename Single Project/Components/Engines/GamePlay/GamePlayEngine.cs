using Gamer.Framework;
using Microsoft.Extensions.Logging;

namespace Gamer.Components.Engines.GamePlay;

public class GamePlayEngine : ServiceObject<GamePlayEngine>, IGamePlayEngine	
{

	public GamePlayEngine(ILogger logger) 
		: base(logger)
	{

	}

}