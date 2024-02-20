using System.ComponentModel.DataAnnotations;

namespace Mission06_McGuire.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public string Title { get; set; } // Movie title is the primary key because it is unique

        [Required]
        public string Category { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool? Edited { get; set; }

        public string LentTo { get; set; }

        [Range(0, 25)] // This is a range of 0 to 25 characters
        public string Notes { get; set; }
    }
}
