using Gamer.Components.Shared.Enums;
using Gamer.Components.Shared.Models;
using Gamer.Framework.Factories;

namespace Gamer.Components.Accessors.Helpers;

internal static class GamePlayerFactory
{

    public static GamePlayer Create(string name, string token, PlayerType playerType)
    {
        var instance = BusinessObjectFactory.Create<GamePlayer>();
        instance.Name = name;
        instance.Token = token;
        instance.PlayerType = playerType;
        instance.Token = token;        
        return instance;
    }

}