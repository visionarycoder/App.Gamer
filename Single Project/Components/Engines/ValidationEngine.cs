using Gamer.Framework;
using Microsoft.Extensions.Logging;

namespace Gamer.Components.Engines;

public class ValidationEngine : ServiceObject<ValidationEngine>
{

    public ValidationEngine(ILogger logger)
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