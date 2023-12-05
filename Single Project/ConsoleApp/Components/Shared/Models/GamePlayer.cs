using Gamer.Components.Shared.Enums;
using Gamer.Framework.Base;

namespace Gamer.Components.Shared.Models;

public sealed class GamePlayer : BusinessObject, IEquatable<GamePlayer>
{
    public string Name { get; set; } = string.Empty;
	public PlayerType PlayerType { get; set; }
	public string Token { get; set; } = string.Empty;

    public ICollection<GameSession> GameSessions { get; set; } = new List<GameSession>();

    public bool Equals(GamePlayer? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name && PlayerType == other.PlayerType && Token == other.Token && GameSessions.Equals(other.GameSessions);
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is GamePlayer other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, (int) PlayerType, Token, GameSessions);
    }

    public static bool operator ==(GamePlayer? left, GamePlayer? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(GamePlayer? left, GamePlayer? right)
    {
        return !Equals(left, right);
    }
}