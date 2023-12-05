using Gamer.Components.Shared.Enums;
using Gamer.Framework.Base;

namespace Gamer.Components.Shared.Models;

public sealed class GameSession : BusinessObject, IEquatable<GameSession>
{
	public int? CurrentPlayerId { get; set; }
	public GamePlayer? CurrentPlayer => Players.SingleOrDefault(p => p.Id == CurrentPlayerId)!;	
	public GameStatus GameStatus { get; set; }
	public GameDefinition GameDefinition { get; set; } = null!;
	public ICollection<GamePlayer> Players { get; set; } = new List<GamePlayer>();
	public ICollection<GameCell> Cells { get; set; } = new List<GameCell>();
	public DateTime Created { get; init; } = DateTime.UtcNow;
	public DateTime? Updated { get; set; }
	public ICollection<GameTurn> GameTurns { get; } = new List<GameTurn>();

    public bool Equals(GameSession? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return CurrentPlayerId == other.CurrentPlayerId && GameStatus == other.GameStatus && GameDefinition.Equals(other.GameDefinition) && Players.Equals(other.Players) && Cells.Equals(other.Cells) && Created.Equals(other.Created) && Nullable.Equals(Updated, other.Updated) && GameTurns.Equals(other.GameTurns);
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is GameSession other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CurrentPlayerId, (int) GameStatus, GameDefinition, Players, Cells, Created, Updated, GameTurns);
    }

    public static bool operator ==(GameSession? left, GameSession? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(GameSession? left, GameSession? right)
    {
        return !Equals(left, right);
    }
}