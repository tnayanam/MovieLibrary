using MovieLibrary.Models;
using MovieLibrary.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MovieLibrary.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie
            {
                Name = "Shrek"
            };

            var customers = new List<Customer>
            {
                new Customer
                {
                    Name = "Tanuj"
                },
                new Customer
                {
                    Name ="Nayanam"
                }
            };

            var viewModel = new RandomMovieViewModel
            {
                Customers = customers,
                Movie = movie
            };

            return View(viewModel);
        }
    }
}