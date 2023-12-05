using Gamer.Framework.Base;

namespace Gamer.Components.Shared.Models;

public sealed class GameCell : BusinessObject, IEquatable<GameCell>
{

  public GameSession GameSession { get; set; } = null!;
  public BoardPosition BoardPosition { get; set; } = null!;
  public string Token { get; set; } = string.Empty;

  public bool Equals(GameCell? other)
  {
      
      if (ReferenceEquals(null, other)) 
          return false;
      
      if (ReferenceEquals(this, other)) 
          return true;
      
      return GameSession.Equals(other.GameSession) && BoardPosition.Equals(other.BoardPosition) && Token == other.Token;

  }

  public override bool Equals(object? obj)
  {
      return ReferenceEquals(this, obj) || obj is GameCell other && Equals(other);
  }

  public override int GetHashCode()
  {
      return HashCode.Combine(GameSession, BoardPosition, Token);
  }

}