using System;
using System.ComponentModel.DataAnnotations;

namespace Access.Game.Orm.Models
{
    public class GameSession
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [Required]
        [MaxLength(100)]
        public string Player { get; set; }

        // Navigation property
        public GameDefinition Game { get; set; }
    }
}
