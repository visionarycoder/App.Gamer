using Gamer.Framework;
using Microsoft.Extensions.Logging;

namespace Gamer.Components.Engines.Rules;

public class GamePlayEngine : ServiceObject<GamePlayEngine>, IGamePlayEngine	
{
	public GamePlayEngine(ILogger logger) 
		: base(logger)
	{

	}

}