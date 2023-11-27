using System.ComponentModel.DataAnnotations;

namespace Gamer.Framework.Enums;

public enum GameStatus
{
    [Display(Name = "Error")] Error,
    [Display(Name = "Unknown")] Unknown,
    [Display(Name = "Not Started")] NotStarted,
    [Display(Name = "In Progress")] InProgress,
    [Display(Name = "Completed")] Completed
}