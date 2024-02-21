using Microsoft.EntityFrameworkCore;

namespace Mission06_McGuire.Models
{
    // This is a special context class that inherits from DBContext
    public class MovieContext: DbContext // Liaison between the app to the database
    {
        // Constructor takes inherited DBContext and makes the MovieContext have the base options
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        // Create a public database set of type Movie (from model Movie.cs)
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {CategoryId = 1, CategoryName = "Miscellaneous"},
                new Category {CategoryId = 2, CategoryName = "Drama"},
                new Category {CategoryId = 3, CategoryName = "Television"},
                new Category {CategoryId = 4, CategoryName = "Horror/Suspense"},
                new Category {CategoryId = 5, CategoryName = "Comedy"},
                new Category {CategoryId = 6, CategoryName = "Family"},
                new Category {CategoryId = 7, CategoryName = "Action/Adventure"},
                new Category {CategoryId = 8, CategoryName = "VHS"}
            );
        }
    }
}