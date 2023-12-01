using System.ComponentModel.DataAnnotations;

namespace Gamer.Components.Shared.Enums;

public enum PlayerType : int
{
	[Display(Name = "Unknown")] Unknown = 0,
	[Display(Name = "Human")] Human,
	[Display(Name = "Computer")] Computer
}