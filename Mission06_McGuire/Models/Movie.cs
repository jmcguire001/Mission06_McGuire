using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_McGuire.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Categories Category { get; set; }

        [Required]
        public string Title { get; set; } // Movie title is the primary key because it is unique

        [Required]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [Required]
        public int CopiedToPlex { get; set; }

        [Range(0, 25)] // This is a range of 0 to 25 characters
        public string? Notes { get; set; }
    }
}
