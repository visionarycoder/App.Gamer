using System.ComponentModel.DataAnnotations;

namespace Gamer.Components.Shared.Enums;

public enum GameType : int
{
	[Display(Name = "Unknown")] Unknown = 0,
	[Display(Name = "Board Game")] BoardGame,
	[Display(Name = "Card Game")] CardGame,
	[Display(Name = "Dice Game")] DiceGame
}