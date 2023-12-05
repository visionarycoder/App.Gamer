namespace Gamer.Components.Shared.Models;

public sealed class BoardDefinition : IEquatable<BoardDefinition>
{

    public int RowCount { get; init; }
    public int ColumnCount { get; init; }
    public bool AllowOverride { get; init; }

    public bool Equals(BoardDefinition? other)
    {

        if (ReferenceEquals(null, other)) 
            return false;

        if (ReferenceEquals(this, other)) 
            return true;

        return RowCount == other.RowCount && ColumnCount == other.ColumnCount && AllowOverride == other.AllowOverride;

    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is BoardDefinition other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(RowCount, ColumnCount, AllowOverride);
    }

    public static bool operator ==(BoardDefinition? left, BoardDefinition? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(BoardDefinition? left, BoardDefinition? right)
    {
        return !Equals(left, right);
    }
}