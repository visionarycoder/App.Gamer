namespace Gamer.Components.Engines.Validation;

public interface IValidationEngine
{
	Task ValidateMoveAsync();
	Task ValidateGameAsync();
}