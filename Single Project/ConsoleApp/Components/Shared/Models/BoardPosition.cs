namespace Gamer.Components.Shared.Models;

public sealed class BoardPosition : IEquatable<BoardPosition>
{

  public int Row { get; init; }
  public int Column { get; init; }

  public bool Equals(BoardPosition? other)
  {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return Row == other.Row && Column == other.Column;
  }

  public override bool Equals(object? obj)
  {
      return ReferenceEquals(this, obj) || obj is BoardPosition other && Equals(other);
  }

  public override int GetHashCode()
  {
      return HashCode.Combine(Row, Column);
  }

  public static bool operator ==(BoardPosition? left, BoardPosition? right)
  {
      return Equals(left, right);
  }

  public static bool operator !=(BoardPosition? left, BoardPosition? right)
  {
      return !Equals(left, right);
  }
}