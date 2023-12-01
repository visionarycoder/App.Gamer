using Gamer.Components.Accessors;
using Gamer.Framework;
using Microsoft.Extensions.Logging;

namespace Gamer.Components.Managers;

public class AdminManager : ServiceObject<AdminManager>
{

    private readonly GameAccess boardAccess;
    private readonly PlayersAccess playersAccess;

    public AdminManager(ILogger logger, GameAccess boardAccess, PlayersAccess playersAccess)
        : base(logger)
    {
        this.boardAccess = boardAccess;
        this.playersAccess = playersAccess;
    }

}