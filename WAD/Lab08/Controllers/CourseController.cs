using Lab08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab08.Controllers
{
    public class CourseController : Controller
    {
        SchoolContext db = new SchoolContext();

        // GET: Course
        public ActionResult Index()
        {
            return View(db.CourseList.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course newCourse)
        {
            if (ModelState.IsValid)
            {
                db.CourseList.Add(newCourse);
                db.SaveChanges();
                ModelState.AddModelError("", "Create course completed");
            }
            return View();
        }
    }
}