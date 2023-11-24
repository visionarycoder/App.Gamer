using Gamer.Framework;
using Microsoft.Extensions.Logging;

namespace Gamer.Components.Accessors.Games
{
    public class GamesAccess : ServiceObject<GamesAccess>, IGamesAccess
    {
	    public GamesAccess(ILogger logger) 
		    : base(logger)
	    {
	    }
    }
}
