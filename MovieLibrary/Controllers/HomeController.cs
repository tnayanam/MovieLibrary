﻿using System.Web.Mvc;
using System.Web.UI;

namespace MovieLibrary.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [OutputCache(Duration = 60, Location = OutputCacheLocation.Server, VaryByParam = "*")]
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            throw new HttpAntiForgeryException();
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}