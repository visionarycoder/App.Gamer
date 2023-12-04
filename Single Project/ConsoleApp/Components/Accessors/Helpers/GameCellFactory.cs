using Gamer.Components.Shared.Models;
using Gamer.Framework.Factories;

namespace Gamer.Components.Accessors.Helpers;

internal static class GameCellFactory
{
    
    public static GameCell Create(int x, int y, GameSession gameSession)
    {
        var instance = BusinessObjectFactory.Create<GameCell>();
        instance.GameSession = gameSession;
        instance.BoardPosition = new BoardPosition
        {
            Row = x,
            Column = y
        };
        return instance;
    }

}