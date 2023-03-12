using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        
        TravelTripDbEntities db = new TravelTripDbEntities();
        BlogComment blogComment = new BlogComment();

        public ActionResult Index()
        {
            var values = db.Blogs.ToList();
            var comment = db.Comments.ToList();
            return View(Tuple.Create(values, comment));
        }

        public ActionResult BlogDetail(int id)
        {
            var value = db.Blogs.Where(b => b.Id == id).ToList();
            var comment = db.Comments.Where(c => c.BlogId == id).ToList();
            //blogComment.Blog1 = db.Blogs.Where(b => b.Id == id).ToList();
            //blogComment.Comment1 = db.Comments.Where(c => c.Blog_Id == id).ToList();

            return View(Tuple.Create(value, comment));
        }

        public PartialViewResult Partial1()
        {
            var blog = db.Blogs.ToList();
            return PartialView(blog);
        }

        public PartialViewResult Partial2()
        {
            var blog = db.Comments.ToList();
            return PartialView(blog);
        }

        [HttpGet]
        public PartialViewResult DoComment(int id)
        {
            ViewBag.value = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult DoComment(Comments comments)
        {
            db.Comments.Add(comments);
            db.SaveChanges();
            return PartialView();
        }
    }
}