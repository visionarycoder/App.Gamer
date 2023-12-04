using Gamer.Components.Shared.Enums;
using Gamer.Components.Shared.Models;
using Gamer.Framework.Factories;

namespace Gamer.Components.Accessors.Helpers;

internal static class GameSessionFactory
{

    public static GameSession Create(GameDefinition gameDefinition, ICollection<GamePlayer>? players = null)
    {
        
        var gameSession = BusinessObjectFactory.Create<GameSession>();
        gameSession.Players = players!.Distinct().ToList();
        gameSession.Cells = new List<GameCell>();
        gameSession.GameDefinition = gameDefinition;
        gameSession.GameStatus = GameStatus.Created;

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