using Gamer.Components.Shared.Enums;

namespace Gamer.Components.Shared.Extensions;

public static class PlayerTypeExtension
{

    public static PlayerType ToType(this string source)
    {
        if (Enum.TryParse<PlayerType>(source, out var target))
            return target;
        return PlayerType.Unknown;
    }

    public static string ToName(this PlayerType source)
    {
        return
            Enum.GetName(typeof(PlayerType), source)
            ?? Enum.GetName(typeof(PlayerType), PlayerType.Unknown)
            ?? string.Empty;
    }

}