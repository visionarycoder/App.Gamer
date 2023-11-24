using Gamer.Framework;
using Microsoft.Extensions.Logging;

namespace Gamer.Components.Managers.Admin;

public class AdminManager : ServiceObject<AdminManager>, IAdminManager
{
	public AdminManager(ILogger logger) 
		: base(logger)
	{

	}

}