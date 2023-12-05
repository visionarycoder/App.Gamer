using Gamer.Components.Accessors;
using Gamer.Components.Engines;
using Gamer.Components.Engines.Models;
using Gamer.Components.Shared.Models;
using Gamer.Framework.Base;

namespace Gamer.Components.Managers;

public class ContentManager : ServiceObject<ContentManager>
{


    private readonly GameAccess gameAccess;
    private readonly PlayersAccess playersAccess;
    private readonly GamePlayEngine gamePlayEngine;

    public ContentManager(GamePlayEngine gamePlayEngine, GameAccess gameAccess, PlayersAccess playersAccess)
    {

        this.gamePlayEngine = gamePlayEngine;

        this.gameAccess = gameAccess;
        this.playersAccess = playersAccess;

    }

    public TicTacToeBoard GetBoard(int gameSessionId)
    {
        return gamePlayEngine.GetTicTacToeBoard(gameSessionId);
    }

    public ICollection<GameDefinition> GetGameDefinitions()
    {
        var gameDefinitions = gameAccess.ListGameDefinitions();
        return gameDefinitions;
    }

    public GameDefinition CreateGameDefinition(string name, string description, BoardDefinition boardDefinition)
    {
        var gameDefinition = gameAccess.CreateGameDefinition(name, description, boardDefinition);
        return gameDefinition;
    }

}