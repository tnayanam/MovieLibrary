using MovieLibrary.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MovieLibrary.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View(GetMovies());
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie
                {
                    Id=1,
                    Name="Shrek"
                },
                new Movie
                {
                    Id =2,
                    Name="Forest Gump"
                }
            };
        }

    }
}