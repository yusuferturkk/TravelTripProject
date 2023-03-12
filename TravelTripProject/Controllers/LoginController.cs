using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProject.Models;

namespace TravelTripProject.Controllers
{
    public class LoginController : Controller
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
            var value = db.Admins.Where(x => x.Username == admins.Username & x.Password == admins.Password).FirstOrDefault();
            if(value != null) 
            {
                FormsAuthentication.SetAuthCookie(value.Username, false);
                Session["Username"] = admins.Username;
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}