using Lab06.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab06.Controllers
{
    public class UsersController : Controller
    {
        SaleDBContext db = new SaleDBContext();

        // GET: User
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
                newUser.Passcode = PasscodeSecurity.encPasscode(newUser.Passcode);
                db.Entry(newUser).State = EntityState.Added;
                db.SaveChanges();
                ModelState.AddModelError("", "Add user completed!");
                TempData["Msg"] = "Add user completed!";
            }
            return View();
        }
    }
}