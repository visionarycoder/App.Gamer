using System;
using System.ComponentModel.DataAnnotations;

namespace Access.Game.Orm
{
    public class GameDefinition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [MaxLength(50)]
        public string Genre { get; set; }

        [MaxLength(100)]
        public string Developer { get; set; }

        // Other properties
    }
}
