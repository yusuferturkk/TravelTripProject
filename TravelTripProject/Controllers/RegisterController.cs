using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models;

namespace TravelTripProject.Controllers
{
    public class RegisterController : Controller
    {

        TravelTripDbEntities db = new TravelTripDbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admins admins)
        {
            db.Admins.Add(admins);
            db.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}