using Microsoft.AspNetCore.Mvc;
using Mission06_McGuire.Models;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace Mission06_McGuire.Controllers
{
    public class HomeController : Controller
    {
        // This is the context file that will be used to build the database
        private MovieContext _context;

        public HomeController(MovieContext temp)
        {
            _context = temp; // Builds an instance of the database using the context file
        }

        // The views (aka actions) are called from the controller
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Meetjoel()
        {
            return View();
        }

        // This is the action that will be used to return the view
        [HttpGet]
        public IActionResult Form()
        {
            // This is a LINQ query that will return a list of categories from the Category database
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Title = "Add to Collection"; // Because this view is reused, make the change unique to filling the form out

            return View("Form", new Movie()); // We need a new instance of Movie() for validation
        }

        // This is the action that will be used to post the data to the database
        [HttpPost]
        public IActionResult Form(Movie response)
        {
            // Check validations
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirm", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList(); // Have to pass the view bag if it's not valid
                ViewBag.Title = "Error"; // Because this view is reused, make the change unique to filling the form out

                return View(response);
            }
        }

        public IActionResult Collection()
        {
            ViewBag.Categories = _context.Categories.ToList();

            // This is a LINQ query that will return a list of movies from the Movie database
            var movie = _context.Movies
                .OrderBy(x => x.Title).
                ToList();

            return View(movie);
        }

        [HttpGet]
        public IActionResult Edit(int id) // Parameter name needs to match the asp-action, which is id
        {
            Movie edit = _context.Movies.Single(x => x.MovieId == id); // This is a LINQ query that will return a single movie from the database
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Title = "Edit Movie Entry"; // Because this view is reused, make the change unique to editing records

            return View("Form", edit);
        }

        [HttpPost]
        public IActionResult Edit(Movie update)
        {
            // Check validations for updating
            if (ModelState.IsValid)
            {
                _context.Movies.Update(update);
                _context.SaveChanges();


                return RedirectToAction("Collection"); // Redirects to the Collection view
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList(); // Have to pass the view bag if it's not valid
                ViewBag.Title = "Error"; // Because this view is reused, make the change unique to filling the form out

                return View("Form", update);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Make sure we get the proper record to send to confirmation
            var delete = _context.Movies.Single(x => x.MovieId == id);

            return View(delete);
        }

        [HttpPost]
        public IActionResult Delete(Movie remove)
        {
            // Delete the proper record
            _context.Movies.Remove(remove);
            _context.SaveChanges();

            // Redirect to the Collection view after deletion
            return RedirectToAction("Collection");
        }
    }
}
