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
            return View();
        }

        // This is the action that will be used to post the data to the database
        [HttpPost]
        public IActionResult Form(Movie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return View("Confirm", response);
        }

        public IActionResult Collection()
        {
            var movie = _context.Movies
                .OrderBy(x => x.Title).
                ToList();

            return View(movie);
        }
    }
}
