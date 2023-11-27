using Gamer.Components.Accessors.Models;

namespace Gamer.Components.Accessors.Extensions;

public static class CellExtension
{
    public static bool IsEmpty(this Cell cell)
    {
        ArgumentNullException.ThrowIfNull(cell, nameof(cell));
        return cell.Player?.Token is null;
    }

}