using System.ComponentModel.DataAnnotations;

namespace Gamer.Framework.Enums;

public enum GameType
{
	[Display(Name = "Unknown")] Unknown = 0,
	[Display(Name = "Board Game")] BoardGame,
	[Display(Name = "Card Game")] CardGame,
	[Display(Name = "Dice Game")] DiceGame
}