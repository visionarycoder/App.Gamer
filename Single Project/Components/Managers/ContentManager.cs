using Gamer.Components.Accessors;
using Gamer.Framework;

using Microsoft.Extensions.Logging;

namespace Gamer.Components.Managers;

public class ContentManager : ServiceObject<ContentManager>
{

    private readonly BoardAccess boardAccess;
    private readonly PlayersAccess playersAccess;

    public ContentManager(ILogger logger, BoardAccess boardAccess, PlayersAccess playersAccess)
        : base(logger)
    {
        this.boardAccess = boardAccess;
        this.playersAccess = playersAccess;
    }

}