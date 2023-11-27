using System.ComponentModel.DataAnnotations;
using Gamer.Framework.Enums;

namespace Gamer.Components.Accessors.Models;

public class Player
{
	public int Id { get; init; }
	public string Name { get; init; } = string.Empty;
	public PlayerType PlayerType { get; init; }
	public string Token { get; set; }
	public ICollection<Session> Sessions { get; init; } = new List<Session>();
}