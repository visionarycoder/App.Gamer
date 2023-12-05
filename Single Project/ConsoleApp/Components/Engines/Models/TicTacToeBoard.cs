using Gamer.Components.Shared.Models;

namespace Gamer.Components.Engines.Models
{

    public class TicTacToeBoard : IEquatable<TicTacToeBoard>
    {

        private readonly ICollection<GameCell> cells;

        public BoardPosition A1 => cells.Single(i => i.BoardPosition is { Row: 0, Column: 0 }).BoardPosition;
        public BoardPosition A2 => cells.Single(i => i.BoardPosition is { Row: 0, Column: 1 }).BoardPosition;
        public BoardPosition A3 => cells.Single(i => i.BoardPosition is { Row: 0, Column: 2 }).BoardPosition;
        public BoardPosition B1 => cells.Single(i => i.BoardPosition is { Row: 1, Column: 0 }).BoardPosition;
        public BoardPosition B2 => cells.Single(i => i.BoardPosition is { Row: 1, Column: 1 }).BoardPosition;
        public BoardPosition B3 => cells.Single(i => i.BoardPosition is { Row: 1, Column: 2 }).BoardPosition;
        public BoardPosition C1 => cells.Single(i => i.BoardPosition is { Row: 2, Column: 0 }).BoardPosition;
        public BoardPosition C2 => cells.Single(i => i.BoardPosition is { Row: 2, Column: 1 }).BoardPosition;
        public BoardPosition C3 => cells.Single(i => i.BoardPosition is { Row: 2, Column: 2 }).BoardPosition;

        public TicTacToeBoard(ICollection<GameCell> cells)
        {
            this.cells = cells;
        }

        public bool Equals(TicTacToeBoard? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return cells.Equals(other.cells);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TicTacToeBoard) obj);
        }

        public override int GetHashCode()
        {
            return cells.GetHashCode();
        }

        public static bool operator ==(TicTacToeBoard? left, TicTacToeBoard? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TicTacToeBoard? left, TicTacToeBoard? right)
        {
            return !Equals(left, right);
        }
    }

}
