using Gamer.Components.Accessors;
using Gamer.Components.Engines.Helpers;
using Gamer.Components.Engines.Models;
using Gamer.Components.Shared.Models;
using Gamer.Framework;
using Gamer.Framework.Base;

namespace Gamer.Components.Engines;

public class GamePlayEngine : ServiceObject<GamePlayEngine>
{

    private readonly GameAccess gameAccess;

    public GamePlayEngine(GameAccess gameAccess)
    {
        this.gameAccess = gameAccess;
    }

    public bool IsGameOver(int sessionId)
    {

        var isGameOver = false;
        var gameSession = gameAccess.GetGameSession(sessionId);
        if (gameSession is null)
        {
                throw new ArgumentException($"Game session {sessionId} not found.");
        }

        foreach (var logicalRow in gameSession.GetLogicalRows().Where(i => i.Count > 0))
        {
            var first = logicalRow[0];
            if (logicalRow.Any(c => c.Token.Length == 0) && logicalRow.All(c => c.Token == first.Token))
                return false;
        }

        return true;

    }

    public GameSession PlayTurn(int gameSessionId, int playerId, int row, int column)
    {

        var gameSession = gameAccess.GetGameSession(gameSessionId);
        if (gameSession is null)
        {
            throw new ArgumentException($"Game session {gameSessionId} not found.");
        }

        var player = gameSession.Players.SingleOrDefault(p => p.Id == playerId);
        if (player is null)
        {
            throw new ArgumentException($"GamePlayer {playerId} not found.");
        }

        var boardPosition = new BoardPosition
        {
            Row = row,
            Column = column
        };
        var turn = new GameTurn
        {
            BoardPosition = boardPosition,
            GamePlayer = player,
            GameSession = gameSession
        };

        gameSession.AddTurn(turn);
        gameSession.UpdateCell(boardPosition, player.Token);
        gameSession.UpdateCurrentPlayer(player);
        return gameSession;

    }

    public TicTacToeBoard CreateTicTacToeBoard(ICollection<GamePlayer> players)
    {
        
        var gameDefinition = gameAccess.ListGameDefinitions().SingleOrDefault(i => i.Name == Constant.TIC_TAC_TOE_NAME);
        if (gameDefinition is null)
        {
            throw new ApplicationException($"{Constant.TIC_TAC_TOE_NAME} is not defined.");
        }

        var session = gameAccess.CreateGameSession(gameDefinition, players);
        var board = new TicTacToeBoard(session.Cells);
        return board;

    }

    public TicTacToeBoard GetTicTacToeBoard(int gameSessionId)
    {

        throw new NotImplementedException();

        //var gameSession = gameAccess.GetGameSession(gameSessionId);
        //if (gameSession is null)
        //{
        //    gameAccess.CreateGameSession();
        //}
        //var board = new TicTacToeBoard();
        //return board;
    }

}