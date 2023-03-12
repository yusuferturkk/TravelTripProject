using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {

        TravelTripDbEntities db = new TravelTripDbEntities();

        [Authorize]
        public ActionResult Index()
        {
            var values = db.Blogs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBlog(Blogs blogs)
        {
            db.Blogs.Add(blogs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBlog(int id)
        {
            var value = db.Blogs.Find(id);
            db.Blogs.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            var value = db.Blogs.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateBlog(Blogs blogs)
        {
            var value = db.Blogs.Find(blogs.Id);
            value.Title = blogs.Title;
            value.Date = blogs.Date;
            value.BlogImage = blogs.BlogImage;
            value.Description = blogs.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CommentList()
        {
            var comments = db.Comments.ToList();
            return View(comments);
        }

        public ActionResult DeleteComment(int id)
        {
            var value = db.Comments.Find(id);
            db.Comments.Remove(value);
            db.SaveChanges();
            return RedirectToAction("CommentList", "Admin");
        }

        [HttpGet]
        public ActionResult UpdateComment(int id)
        {
            var value = db.Comments.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateComment(Comments comments)
        {
            var value = db.Comments.Find(comments.Id);
            value.UserName = comments.UserName;
            value.Email = comments.Email;
            value.Comments1 = comments.Comments1;

            var blog = db.Blogs.Where(x => x.Id == comments.BlogId).FirstOrDefault();
            value.BlogId = blog.Id;

            db.SaveChanges();
            return RedirectToAction("CommentList", "Admin");
        }
    }
}