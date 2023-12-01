using Gamer.Components.Shared.Models;

namespace Gamer.Components.Accessors.Helpers;

internal static class GameDefinitionFactory
{

    private static int id;

    public static GameDefinition Create(string name, string description, BoardDefinition boardDefinition)
    {
        var entry = new GameDefinition
        {
            Id = id++,
            Name = name,
            Description = description,
            BoardDefinition = boardDefinition
        };
        return entry;
    }

}