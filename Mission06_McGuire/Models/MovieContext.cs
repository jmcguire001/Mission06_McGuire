using Microsoft.EntityFrameworkCore;

namespace Mission06_McGuire.Models
{
    // This is a special context class that inherits from DBContext
    public class MovieContext: DbContext
    {
        // Constructor takes inherited DBContext and makes the MovieContext have the base options
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        // Create a public database set of type Movie (from model Movie.cs)
        public DbSet<Movie> Movies { get; set; }
    }
}