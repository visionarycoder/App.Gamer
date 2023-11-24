using Gamer.Framework;

using Microsoft.Extensions.Logging;

namespace Gamer.Components.Managers.Content;

public class ContentManager : ServiceObject<ContentManager>, IContentManager
{
	
	public ContentManager(ILogger logger)
		: base(logger)
	{

	}

}