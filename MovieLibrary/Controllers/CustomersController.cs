using MovieLibrary.Models;
using MovieLibrary.ViewModel;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
namespace MovieLibrary.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CustomerFormViewModel viewModel)
        {
            var customer = new Customer
            {
                Birthdate = viewModel.Customer.Birthdate,
                Name = viewModel.Customer.Name,
                IsSubscribedToNewsletter = viewModel.Customer.IsSubscribedToNewsletter,
                MembershipTypeId = viewModel.Customer.MembershipTypeId
            };

            _context.Customers.Add(customer); // in memory
            _context.SaveChanges(); // save to Db
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers
                .SingleOrDefault(c => c.Id == id);
            var membershipTypes = _context.MembershipTypes.ToList();
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers
                .Include(c => c.MembershipType)
                .ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers
                  .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}