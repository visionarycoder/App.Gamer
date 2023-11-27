using Gamer.Components.Accessors.Models;
using Gamer.Framework;
using Gamer.Resources.Data.GamerDb;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Gamer.Components.Accessors;

public class BoardAccess : ServiceObject<BoardAccess>
{

    private readonly GamerContext ctx;

    public BoardAccess(ILogger logger, DbContextOptions<GamerContext> options)
        : base(logger)
    {
        ctx = new GamerContext(options);
    }

}