using MovieLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MovieLibrary.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View(GetCustomers());
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Tanuj Nayanam"
                },
                new Customer
                {
                    Id = 2,
                    Name ="Rajesh Kumar"
                }
            };
        }
    }
}