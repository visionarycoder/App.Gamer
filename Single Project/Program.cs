using Gamer.Clients.Content;
using Gamer.Components.Accessors;
using Gamer.Components.Engines;
using Gamer.Components.Managers;
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

var options = new DbContextOptionsBuilder<GamerContext>()
	.UseSqlite(builder.Configuration.GetConnectionString("Gamer"))
	.Options;
builder.Services.AddSingleton(options);

builder.Services.AddDbContext<GamerContext>();

builder.Services.AddTransient<BoardAccess>();
builder.Services.AddTransient<PlayersAccess>();
builder.Services.AddTransient<GamePlayEngine>();
builder.Services.AddTransient<ValidationEngine>();
builder.Services.AddTransient<AdminManager>();
builder.Services.AddTransient<ContentManager>();
builder.Services.AddTransient<ContentClient>();

var host = builder.Build();

await host.RunAsync();

