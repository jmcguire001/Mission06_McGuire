using System.ComponentModel.DataAnnotations;

namespace Mission06_McGuire.Models
{
    public class Category
    {
        // Build the Category database
        [Key]
        public int? CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}
