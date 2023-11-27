using Gamer.Framework;

using Microsoft.Extensions.Logging;

namespace Gamer.Components.Engines
{

	public class BoardEngine : ServiceObject<BoardEngine>
	{

		public BoardEngine(ILogger logger)
			: base(logger)
		{

		}

	}

}
