using Gamer.Clients.Content;
using Gamer.Components.Accessors.Games;
using Gamer.Components.Accessors.Players;
using Gamer.Components.Engines.GamePlay;
using Gamer.Components.Managers.Admin;
using Gamer.Components.Managers.Content;
using Gamer.Resources.Data.GamerDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddJsonFile("AppSettings.json", optional: true);
builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddCommandLine(args);
builder.Logging.AddSimpleConsole(options =>
	{
		options.IncludeScopes = true;
		options.SingleLine = true;
		options.TimestampFormat = "hh:mm:ss ";
	});

builder.Services.AddDbContext<GamerContext>(options =>
{
	options.UseSqlite(builder.Configuration.GetConnectionString("Gamer"));
});

builder.Services.AddTransient<IGamesAccess, GamesAccess>();
builder.Services.AddTransient<IPlayersAccess, PlayersAccess>();
builder.Services.AddTransient<IGamePlayEngine, GamePlayEngine>();
builder.Services.AddTransient<IGamePlayRules, GamePlayRules>();
builder.Services.AddTransient<IValidationEngine, ValidationEngine>();
builder.Services.AddTransient<IAdminManager, AdminManager>();
builder.Services.AddTransient<IContentManager, ContentManager>();
builder.Services.AddTransient<IContentClient, ContentClient>();

var host = builder.Build();
await host.RunAsync();

