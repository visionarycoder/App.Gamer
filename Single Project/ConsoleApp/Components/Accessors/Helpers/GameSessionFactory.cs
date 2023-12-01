using Gamer.Components.Shared.Enums;
using Gamer.Components.Shared.Models;

namespace Gamer.Components.Accessors.Helpers;

internal static class GameSessionFactory
{

    private static int id;

    public static GameSession Create(GameDefinition gameDefinition, ICollection<Player>? players = null)
    {
        
        var playerList = players ?? new List<Player>();
        playerList = playerList.Distinct().ToList();

        var gameSession = new GameSession
        {
            Id = id++,
            Players = playerList,
            Cells = new List<GameCell>(),
            Created = DateTime.Now,
            Updated = DateTime.Now,
            GameStatus = GameStatus.NotStarted,
            GameDefinition = gameDefinition,
        };
        
        for (var rowIdx = 0; rowIdx < gameDefinition.BoardDefinition.RowCount; rowIdx++)
        {
            for (var columnIdx = 0; columnIdx < gameDefinition.BoardDefinition.ColumnCount; columnIdx++)
            {
                var cell = GameCellFactory.Create(rowIdx, columnIdx, gameSession);                
                gameSession.Cells.Add(cell);
            }
        }
        return gameSession;

    }

}