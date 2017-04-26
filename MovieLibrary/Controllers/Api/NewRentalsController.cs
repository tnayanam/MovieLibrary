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
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id));
            //select * from movies where id in (1,2,3)

            foreach (var movie in movies)
            {
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
