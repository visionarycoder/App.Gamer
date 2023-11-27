using System.ComponentModel.DataAnnotations;
using Gamer.Framework.Enums;

namespace Gamer.Components.Accessors.Models;

public class Session
{
	public int Id { get; init; }
	public int CurrentPlayerId { get; set; }
	public GameStatus GameStatus { get; set; }
	public Definition Definition { get; init; } = null!;
	public ICollection<Player> Players { get; init; } = new List<Player>();
	public ICollection<Cell> Cells { get; init; } = new List<Cell>();
}