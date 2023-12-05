using Gamer.Components.Shared.Models;
using Gamer.Framework.Base;
using System.ComponentModel.DataAnnotations;

namespace Gamer.Components.Engines;

public class ValidationEngine : ServiceObject<ValidationEngine>
{

	public ValidationResult ValidateTurn(GameSession gameSession, GameTurn gameTurn)
	{

		ArgumentNullException.ThrowIfNull(gameSession, nameof(gameSession));
		ArgumentNullException.ThrowIfNull(gameTurn, nameof(gameTurn));

		var target = gameSession.Cells.SingleOrDefault(i => i.BoardPosition == gameTurn.BoardPosition);
		if (target is null)
		{
			return new ValidationResult($"Unable to find matching board position at [{gameTurn.BoardPosition.Row}, {gameTurn.BoardPosition.Column}].");
		}

		if (gameSession.GameDefinition.AllowOverwrite || string.IsNullOrWhiteSpace(target.Token))
		{
			target.Token = gameTurn.GamePlayer.Token;
			return ValidationResult.Success;
		}
		return new ValidationResult($"The board position has already been played.  Existing value = {target.Token} at [{gameTurn.BoardPosition.Row},{gameTurn.BoardPosition.Column}]");

	}

}