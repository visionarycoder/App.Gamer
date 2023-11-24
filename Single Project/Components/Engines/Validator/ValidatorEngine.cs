using Gamer.Framework;
using Microsoft.Extensions.Logging;

namespace Gamer.Components.Engines.Validator
{

	public interface IValidatorEngine
	{
		Task ValidateMoveAsync();
		Task ValidateGameAsync();
	}

	public class ValidatorEngine : ServiceObject<ValidatorEngine>, IValidatorEngine
	{

		public ValidatorEngine(ILogger logger) 
			: base(logger)
		{
		}

		public async Task ValidateMoveAsync()
		{
			throw new NotImplementedException();
		}

		public async Task ValidateGameAsync()
		{
			throw new NotImplementedException();
		}
	}
}
