using Gamer.Components.Shared.Enums;

namespace Gamer.Components.Shared.Extensions;

public static class GameTypeExtension
{

    public static GameType ToType(this string source)
    {
        if (Enum.TryParse<GameType>(source, out var type))
            return type;
        return GameType.Unknown;
    }

    public static string ToName(this GameType source)
    {
        return
            Enum.GetName(typeof(GameType), source)
            ?? Enum.GetName(typeof(GameType), GameType.Unknown)
            ?? string.Empty;
    }

}