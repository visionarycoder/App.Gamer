using Gamer.Components.Shared.Models;
using Gamer.Framework;

namespace Gamer.Components.Engines.Models;

internal class Turn : BusinessObject
{
    public BoardPosition BoardPosition { get; init; }
    public Player Player { get; init; } = null!;
    public GameSession GameSession { get; init; } = null!;
}