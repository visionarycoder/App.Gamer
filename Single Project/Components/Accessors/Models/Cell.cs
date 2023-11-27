using System.ComponentModel.DataAnnotations;
using Gamer.Framework;

namespace Gamer.Components.Accessors.Models;

public class Cell
{
	
	public int Id { get; init; }

	public int X { get; set; }
	public int Y { get; set; }

	public virtual Session Session { get; init; } = null!;
	public virtual Player? Player { get; set; }

}