using MovieLibrary.Dtos;
using MovieLibrary.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace MovieLibrary.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            //if (newRental.MovieIds.Count == 0)
            //    return BadRequest("No mvoie to add");

            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            //if (customer == null)
            //    return BadRequest("CustomerId is not valid");



            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
            //select * from movies where id in (1,2,3)
            //if (movies.Count != newRental.MovieIds.Count)
            //    return BadRequest("one or more mvoiesId are invalid");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie not available");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Movie = movie,
                    Customer = customer,
                    DateRented = DateTime.Now
                };

                _context.SaveChanges();
            }

            return Ok();


            throw new NotImplementedException();
        }
    }
}
