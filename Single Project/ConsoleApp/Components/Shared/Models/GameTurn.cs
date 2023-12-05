using Gamer.Framework.Base;

namespace Gamer.Components.Shared.Models;

public class GameTurn : BusinessObject, IEquatable<GameTurn>
{

    public BoardPosition BoardPosition { get; init; } = null!;
    public GamePlayer GamePlayer { get; init; } = null!;
    public GameSession GameSession { get; init; } = null!;
    public GameAction GameAction { get; init; } = GameAction.Undefined;

    public bool Equals(GameTurn? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return BoardPosition.Equals(other.BoardPosition) && GamePlayer.Equals(other.GamePlayer) && GameSession.Equals(other.GameSession) && GameAction == other.GameAction;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((GameTurn) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(BoardPosition, GamePlayer, GameSession, (int) GameAction);
    }

    public static bool operator ==(GameTurn? left, GameTurn? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(GameTurn? left, GameTurn? right)
    {
        return !Equals(left, right);
    }

}