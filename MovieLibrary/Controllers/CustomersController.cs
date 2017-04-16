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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes,
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(NewCustomerViewModel viewModel)
        {
            var customer = new Customer
            {
                Birthdate = viewModel.Customer.Birthdate,
                Name = viewModel.Customer.Name,
                IsSubscribedToNewsletter = viewModel.Customer.IsSubscribedToNewsletter,
                MembershipTypeId = viewModel.Customer.MembershipTypeId
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
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