using Gamer.Components.Shared.Enums;
using Gamer.Framework;

namespace Gamer.Components.Shared.Models;

public sealed class GamePlayer : BusinessObject
{
    public string Name { get; set; } = string.Empty;
	public PlayerType PlayerType { get; set; }
	public string Token { get; set; } = string.Empty;

    public ICollection<GameSession> GameSessions { get; set; } = new List<GameSession>();
}