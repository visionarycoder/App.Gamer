using Gamer.Components.Accessors;
using Gamer.Components.Shared.Models;
using Gamer.Framework;

namespace Gamer.Components.Engines;

public class GamePlayEngine : ServiceObject<GamePlayEngine>
{

    private readonly GameAccess gameAccess;

    public bool IsGameOver(int sessionId)
    {
        var isGameOver = false;
        var gameSession = gameAccess.GetGameSession(sessionId);
        switch (gameSession)
        {
            case null:
                throw new ArgumentException($"Game session {sessionId} not found.");
        }

        var logicalRows = gameSession.GetLogicalRows();
        foreach (var logicalRow in logicalRows)
        {
            if (logicalRow.Any(c => c.Token == string.Empty))
                return false;
            
        }
        return IsGamePlayable(gameSession);
    }

    public GameSession PlayTurn(int sessionId, int playerId, int row, int column)
    {
        var gameSession = gameAccess.GetGameSession(sessionId);
        switch (gameSession)
        {
            case null:
                throw new ArgumentException($"Game session {sessionId} not found.");
        }
        var player = gameSession.Players.SingleOrDefault(p => p.Id == playerId);
        switch (player)
        {
            case null:
                throw new ArgumentException($"GamePlayer {playerId} not found.");
        }
        var turn = new GameTurn
        {
            BoardPosition = new BoardPosition()
            {
                Row = row,
                Column = column
            },
            GamePlayer = player,
            GameSession = gameSession
        };
        gameSession.AddTurn(turn);
        gameSession.UpdateCell(turn.BoardPosition, player.Token);
        gameSession.UpdateCurrentPlayer(player);
        return gameSession;
    }

}

public static class GameSessionExtension
{

    public static bool IsWinningRow(params GameCell[] cells)
    {
        
        ArgumentNullException.ThrowIfNull(cells, nameof(cells));
        
        return cells.All(c => c.Token == cells.First().Token);

    }

    public static bool IsCellPlayable(GameCell cell)
    {
        
        ArgumentNullException.ThrowIfNull(cell, nameof(cell));
        
        return string.IsNullOrWhiteSpace(cell.Token);

    }

    public static bool IsGamePlayable(GameSession gameSession)
    {
        
        ArgumentNullException.ThrowIfNull(gameSession, nameof(gameSession));
        
        return gameSession.Cells.Any(IsCellPlayable);

    }

    public static List<List<GameCell>> GetLogicalRows(this GameSession source)
    {

        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var lists = new List<List<GameCell>>();

        // By row
        foreach (var rowIdx in Enumerable.Range(0, source.GameDefinition.BoardDefinition.RowCount))
        {
            var list = new List<GameCell>();
            foreach (var columnIdx in Enumerable.Range(0, source.GameDefinition.BoardDefinition.ColumnCount))
            {
                var cell = source.Cells.SingleOrDefault(c => c.BoardPosition.Row == rowIdx && c.BoardPosition.Column == columnIdx);
                if (cell != null)
                    list.Add(cell);
            }
            lists.Add(list);
        }

        foreach (var columnIdx in Enumerable.Range(0, source.GameDefinition.BoardDefinition.ColumnCount))
        {
            var list = new List<GameCell>();
            foreach (var rowIdx in Enumerable.Range(0, source.GameDefinition.BoardDefinition.RowCount))
            {
                var cell = source.Cells.SingleOrDefault(c => c.BoardPosition.Row == rowIdx && c.BoardPosition.Column == columnIdx);
                if (cell != null)
                    list.Add(cell);
            }
            lists.Add(list);
        }

        return lists;

    }

    public static void UpdateCell(this GameSession source, BoardPosition boardPosition, string token)
    {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(boardPosition, nameof(boardPosition));

        var cell = source
            .Cells
            .SingleOrDefault(c => c.BoardPosition.Row == boardPosition.Row && c.BoardPosition.Column == boardPosition.Column);
        

        if (cell == null) 
            ArgumentException.ThrowIfNullOrEmpty(cell.ToString(), nameof(cell));

        cell.Token = token;

    }

    public static void AddTurn(this GameSession source, GameTurn turn)
    {
       
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(turn, nameof(turn));

        source.GameTurns.Add(turn);

    }

    public static void UpdateCurrentPlayer(this GameSession source, GamePlayer player)
    {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(player, nameof(player));
        
        var existingPlayer = source.Players.SingleOrDefault(p => p.Id == player.Id);
        source.CurrentPlayerId = existingPlayer switch
        {
            null => throw new ArgumentException($"Player {player.Id} not found."),
            _ => existingPlayer.Id
        };

    }

}