using Gamer.Framework.Base;

namespace Gamer.Components.Shared.Models;

public sealed class GameDefinition : BusinessObject, IEquatable<GameDefinition>
{

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string TurnPrompt { get; init; } = string.Empty;
    public int NumberOfPlayers { get; init; } = 2;
    public bool IsTurnBased { get; init; } = true;
    public bool AllowOverwrite { get; init; } = true;
    public BoardDefinition BoardDefinition { get; set; } = null!;

    public bool Equals(GameDefinition? other)
    {

        if (ReferenceEquals(null, other)) 
            return false;

        if (ReferenceEquals(this, other)) 
            return true;

        return Name == other.Name 
               && Description == other.Description 
               && TurnPrompt == other.TurnPrompt 
               && NumberOfPlayers == other.NumberOfPlayers 
               && IsTurnBased == other.IsTurnBased 
               && AllowOverwrite == other.AllowOverwrite 
               && BoardDefinition.Equals(other.BoardDefinition);
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is GameDefinition other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Description, TurnPrompt, NumberOfPlayers, IsTurnBased, AllowOverwrite, BoardDefinition);
    }

    public static bool operator ==(GameDefinition? left, GameDefinition? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(GameDefinition? left, GameDefinition? right)
    {
        return !Equals(left, right);
    }
}