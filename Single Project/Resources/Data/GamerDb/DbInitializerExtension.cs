using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gamer.Resources.Data.GamerDb;

internal static class DbInitializerExtension
{

	public static IHost SeedGamerDb(this IHost host)		
	{

		ArgumentNullException.ThrowIfNull(host, nameof(host));
		try
		{
			using var scope = host.Services.CreateScope();
			var services = scope.ServiceProvider;
			var ctx = services.GetRequiredService<GamerContext>();
			DbInitializer.Initialize(ctx);
		}
		catch (InvalidOperationException ex)
		{
			Debug.WriteLine(ex);
		}
		return host;

	}

}