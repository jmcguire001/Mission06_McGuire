using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_McGuire.Models
{
    public class Movie
    {
        // Error messages will be shown in the [required] features
        [Key]
        [Required]
        public int MovieId { get; set; }

        // Foreign key that will be used to link the category to the movie
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? CategoryName { get; set; }

        [Required(ErrorMessage = "You must enter a movie title")]
        public string Title { get; set; } // Movie title is the primary key because it is unique

        [Required(ErrorMessage = "You must enter a movie's release year")]
        [Range(1888, int.MaxValue, ErrorMessage = "The year must be post-1888")]
        public int? Year { get; set; }

        public string? Director { get; set; }

        [Required(ErrorMessage = "You must enter a movie rating")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "You must enter whether the movie has been edited")]
        public int? Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "You must enter whether the movie has been copied to plex")]
        public int? CopiedToPlex { get; set; }

        [StringLength(25, ErrorMessage = "Keep Notes fewer than 25 characters")] // This is a range of 0 to 25 characters
        public string? Notes { get; set; }
    }
}
