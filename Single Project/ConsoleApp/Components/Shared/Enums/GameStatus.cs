using System.ComponentModel.DataAnnotations;

namespace Gamer.Components.Shared.Enums;

public enum GameStatus : int
{
    [Display(Name = "Error")] Error,
    [Display(Name = "Unknown")] Unknown,
    [Display(Name = "Not Started")] NotStarted,
    [Display(Name = "In Progress")] InProgress,
    [Display(Name = "Completed")] Completed
}