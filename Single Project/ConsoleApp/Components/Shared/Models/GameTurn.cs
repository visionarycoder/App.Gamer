using Gamer.Framework;

namespace Gamer.Components.Shared.Models;

public class GameTurn : BusinessObject
{
    public BoardPosition BoardPosition { get; init; }
    public GamePlayer GamePlayer { get; init; } = null!;
    public GameSession GameSession { get; init; } = null!;
    public GameAction GameAction { get; init; } = GameAction.Undefined;
}