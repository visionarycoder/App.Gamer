using Gamer.Components.Shared.Enums;
using Gamer.Components.Shared.Models;

namespace Gamer.Components.Accessors.Helpers;

internal static class PlayerFactory
{

    private static int id;

    public static Player Create(string name, string token, PlayerType playerType)
    {
        var entry = new Player
        {
            Id = id++,
            Name = name,
            Token = token,
            PlayerType = playerType
        };
        return entry;
    }

}