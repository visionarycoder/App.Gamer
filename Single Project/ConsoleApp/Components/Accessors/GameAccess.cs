using System.Diagnostics;

using Gamer.Components.Accessors.Helpers;
using Gamer.Components.Shared.Models;
using Gamer.Framework.Base;

namespace Gamer.Components.Accessors;

public class GameAccess : ServiceObject<GameAccess>
{

    private readonly HashSet<GameSession> gameSessions = new();
    private readonly HashSet<GameDefinition> gameDefinitions = new();

    public GameSession? GetGameSession(int sessionId)
    {
        return gameSessions
            .SingleOrDefault(s => s.Id == sessionId);
    }

    public GameCell? GetGameCell(int cellId)
    {
        return gameSessions
            .SelectMany(s => s.Cells)
            .SingleOrDefault(c => c.Id == cellId);
    }

    public GameDefinition? GetGameDefinition(int gameDefinitionId)
    {
        return gameDefinitions
            .SingleOrDefault(g => g.Id == gameDefinitionId);
    }

    public ICollection<GameSession> ListGameSessions()
    {
        return gameSessions;
    }

    public ICollection<GameDefinition> ListGameDefinitions()
    {
        return gameDefinitions;
    }

    public GameSession CreateGameSession(GameDefinition gameDefinition, ICollection<GamePlayer>? players)
    {
        ArgumentNullException.ThrowIfNull(gameDefinition, nameof(gameDefinition));

        var gameSession = GameSessionFactory.Create(gameDefinition, players);
        gameSessions.Add(gameSession);
        return gameSession;
    }

    public GameDefinition CreateGameDefinition(string name, string description, BoardDefinition boardDefinition)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        ArgumentException.ThrowIfNullOrWhiteSpace(description, nameof(description));

        var gameDefinition = GameDefinitionFactory.Create(name, description, boardDefinition);
        gameDefinitions.Add(gameDefinition);
        return gameDefinition;
    }

    public bool Update(GameSession entry)
    {

        ArgumentNullException.ThrowIfNull(entry, nameof(entry));

        var existing = gameSessions.SingleOrDefault(x => x.Id == entry.Id);
        if (existing is null)
        {
            return false;
        }
        existing.GameDefinition = entry.GameDefinition;
        existing.Players = entry.Players;
        existing.Cells = entry.Cells;
        existing.CurrentPlayerId = entry.CurrentPlayerId;
        existing.GameStatus = entry.GameStatus;
        existing.Updated = DateTime.UtcNow;
        return true;

    }

    public bool Update(GameCell entry)
    {
        
        ArgumentNullException.ThrowIfNull(entry, nameof(entry));

        var existing = GetGameCell(entry.Id);
        if (existing is null)
        {
            return false;
        }
        existing.GameSession = entry.GameSession;
        existing.BoardPosition = entry.BoardPosition;
        existing.Token = entry.Token;
        return true;

    }

    public bool Delete(GameSession entry)
    {

        ArgumentNullException.ThrowIfNull(entry, nameof(entry));

        var existing = gameSessions.SingleOrDefault(x => x.Id == entry.Id);
        if (existing is null)
        {
            Debug.WriteLine($"Entry {entry.Id} not found.");
            return false;
        }
        var successful = gameSessions.Remove(existing);
        return successful;

    }

    public bool Delete(GameCell entry)
    {
        ArgumentNullException.ThrowIfNull(entry, nameof(entry));

        var existing = GetGameCell(entry.Id);
        if (existing is null)
        {
            Debug.WriteLine($"Entry {entry.Id} not found.");
            return false;
        }
        var gameSession = existing.GameSession;
        var successful = gameSession.Cells.Remove(existing);
        return successful;
    }

    public bool Delete(GameDefinition entry)
    {
        var existing = GetGameDefinition(entry.Id);
        if (existing is null)
        {
            Debug.WriteLine($"Entry {entry.Id} not found.");
            return false;
        }
        var successful = gameDefinitions.Remove(existing);
        return successful;
    }

}