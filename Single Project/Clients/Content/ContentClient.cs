using Gamer.Framework;
using Microsoft.Extensions.Logging;

namespace Gamer.Clients.Content;

public class ContentClient : ServiceObject<ContentClient>, IContentClient
{
	public ContentClient(ILogger logger) 
		: base(logger)
	{
	}
}


