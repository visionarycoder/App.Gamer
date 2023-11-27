using System.ComponentModel.DataAnnotations;

namespace Gamer.Framework.Enums;

public enum PlayerType
{
	[Display(Name = "Undefined")] Unknown = 0,
	[Display(Name = "Human")] Human,
	[Display(Name = "Computer")] Computer
}