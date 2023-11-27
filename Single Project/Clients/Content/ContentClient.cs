using Gamer.Framework;
using Microsoft.Extensions.Logging;

namespace Gamer.Clients.Content;

public class ContentClient : ServiceObject<ContentClient>
{
	public ContentClient(ILogger logger) 
		: base(logger)
	{
	}
}


