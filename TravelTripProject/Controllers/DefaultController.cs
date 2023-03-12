using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models;

namespace TravelTripProject.Controllers
{
    public class DefaultController : Controller
    {

        TravelTripDbEntities db = new TravelTripDbEntities();

        public ActionResult Index()
        {
            var values = db.Blogs.ToList();
            return View(values);
        }

        public ActionResult About()
        {
            var values = db.Abouts.ToList();
            return View(values);
        }

        public PartialViewResult Partial1()
        {
            var values = db.Blogs.OrderByDescending(b => b.Id).Take(2).ToList();
            return PartialView(values);
        }

        public PartialViewResult Partial2()
        {
            var value = db.Blogs.OrderBy(x => x.Id).Take(1).ToList();
            return PartialView(value);
        }

        public PartialViewResult PartialTop10()
        {
            var values = db.Blogs.OrderBy(b => b.Id).Take(10).ToList();
            return PartialView(values);
        }

        public PartialViewResult Partial4()
        {
            var value = db.Blogs.ToList();
            return PartialView(value);
        }
    }
}