﻿using MovieLibrary.Models;
using MovieLibrary.ViewModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Mvc;
//using System.Runtime.Caching.MemoryCache;
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
            var customer = new Customer();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = membershipTypes,
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer); // in memory
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.Name = customer.Name;
            }

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
            if (MemoryCache.Default["Genres"] == null)
            {
                MemoryCache.Default["Genres"] = _context.Genres.ToList();

            }

            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

            //var customers = _context.Customers
            //    .Include(c => c.MembershipType)
            //    .ToList();

            //return View(customers);
            return View();
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