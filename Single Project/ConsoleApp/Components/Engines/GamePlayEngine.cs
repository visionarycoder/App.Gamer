using Gamer.Components.Accessors;
using Gamer.Components.Engines.Models;
using Gamer.Components.Shared.Models;
using Gamer.Framework;
using Microsoft.Extensions.Logging;

namespace Gamer.Components.Engines;

public class GamePlayEngine : ServiceObject<GamePlayEngine>
{

    private readonly GameAccess gameAccess;

    public bool IsGameOver(int sessionId)
    {
        var gameSession = gameAccess.GetGameSession(sessionId);
        if (gameSession is null)
        {
            throw new ArgumentException($"Game session {sessionId} not found.");
        }
        
    }

    public GameSession PlayTurn(int sessionId, int playerId, int row, int column)
    {
        var gameSession = gameAccess.GetGameSession(sessionId);
        if (gameSession is null)
        {
            throw new ArgumentException($"Game session {sessionId} not found.");
        }
        var player = gameSession.Players.SingleOrDefault(p => p.Id == playerId);
        if (player is null)
        {
            throw new ArgumentException($"Player {playerId} not found.");
        }
        var turn = new Turn
        {
            BoardPosition = new BoardPosition()
            {
                Row = row,
                Column = column
            },
            Player = player,
            GameSession = gameSession
        };
        gameSession.Cells.Add(turn);
        gameSession.CurrentPlayerId = gameSession.Players.Single(p => p.Id != playerId).Id;
        return gameSession;
    }

}