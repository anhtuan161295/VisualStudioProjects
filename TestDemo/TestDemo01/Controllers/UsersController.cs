using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemo01.Models;

namespace TestDemo01.Controllers
{
    public class UsersController : Controller
    {
        DataContext db = new DataContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.UserList.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User newUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newUser).State = EntityState.Added;
                db.SaveChanges();
                ModelState.AddModelError("", "Add user completed");
            }
            return View();
        }

        public JsonResult Details(int id)
        {
            var user = db.UserList.Find(id);

            return Json(user, JsonRequestBehavior.AllowGet);
        }
    }
}