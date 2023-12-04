using Gamer.Components.Shared.Models;
using Gamer.Framework.Factories;

namespace Gamer.Components.Accessors.Helpers;

internal static class GameDefinitionFactory
{
    
    public static GameDefinition Create(string name, string description, BoardDefinition boardDefinition)
    {
        var instance = BusinessObjectFactory.Create<GameDefinition>();
        instance.Name = name;
        instance.Description = description;
        instance.BoardDefinition = boardDefinition;
        return instance;
    }

}