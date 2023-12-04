using System.ComponentModel.DataAnnotations;
using Gamer.Components.Shared.Models;
using Gamer.Framework;

namespace Gamer.Components.Engines;

public class ValidationEngine : ServiceObject<ValidationEngine>
{

    // Does the game type all overwrite of cells?
    private readonly bool allowOverwrite;

    public ValidationEngine()
    {
        allowOverwrite = false;
    }
    public ValidationResult ValidateTurn(GameCell gameCell, GameTurn gameTurn)
    {
                   
    }

}