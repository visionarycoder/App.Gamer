using Gamer.Components.Shared.Models;

namespace Gamer.Components.Accessors.Helpers;

internal static class GameCellFactory
{

    private static int id;

    public static GameCell Create(int x, int y, GameSession gameSession)
    {
        var entry = new GameCell
        {
            Id = id++,
            GameSession = gameSession,
            BoardPosition = new BoardPosition
            {
                Row = x,
                Column = y
            }
        };
        return entry;
    }

}