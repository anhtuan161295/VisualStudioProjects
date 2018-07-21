using Lab07.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab07.Controllers
{
    public class HomeController : Controller
    {
        UserContext db = new UserContext();

        // GET: Home

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexUser()
        {
            var user = Session["User"] as User;
            if (user != null && user.IsAdmin == false)
            {
                return View(db.UserList.Find(user.Username));
            }
            return View();
        }

        public ActionResult IndexAdmin()
        {
            //var user = Session["User"] as User;
            //if (user != null && user.IsAdmin == true)
            //{
            return View(db.UserList.ToList());
            //}
            return View();
        }

        public ActionResult changeLG(string lg)
        {
            Session["lg"] = lg;
            return Redirect(Request.UrlReferrer.AbsoluteUri.ToString());
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
                db.UserList.Add(newUser);
                db.SaveChanges();
                ModelState.AddModelError("", @Lab07.Languages.Lg.AddUserSuccess);
            }
            return View();
        }

        public ActionResult Details(string id)
        {
            return View(db.UserList.Find(id));
        }

        public ActionResult Edit(string id)
        {
            return View(db.UserList.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(User editUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editUser).State = EntityState.Modified;
                db.SaveChanges();
                var user = Session["User"] as User;
                if (user != null && user.IsAdmin == true)
                {
                    return RedirectToAction("IndexAdmin", "Home");
                }
                else if (user != null && user.IsAdmin == false)
                {
                    return RedirectToAction("IndexUser", "Home");
                }
            }
            return View();
        }

        public ActionResult Delete(string id)
        {
            return View(db.UserList.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(User delUser)
        {
            if (delUser != null)
            {
                db.Entry(delUser).State = EntityState.Deleted;
                db.SaveChanges();
                var user = Session["User"] as User;
                if (user != null && user.IsAdmin == true)
                {
                    return RedirectToAction("IndexAdmin", "Home");
                }
                else if (user != null && user.IsAdmin == false)
                {
                    return RedirectToAction("IndexUser", "Home");
                }
            }

            return View();
        }
    }
}