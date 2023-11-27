using Gamer.Framework;
using Microsoft.Extensions.Logging;

namespace Gamer.Components.Engines;

public class GamePlayEngine : ServiceObject<GamePlayEngine>
{

    public GamePlayEngine(ILogger logger)
        : base(logger)
    {

    }

}