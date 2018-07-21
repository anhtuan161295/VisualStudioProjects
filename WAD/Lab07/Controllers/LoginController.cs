using Lab07.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab07.Controllers
{
    public class LoginController : Controller
    {
        UserContext db = new UserContext();
        // GET: Login
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User logUser)
        {
            var user = db.UserList.Find(logUser.Username);
            if (user == null)
            {
                ModelState.AddModelError("", @Lab07.Languages.Lg.UserNotFound);
            }
            else
            {
                if (logUser.Passcode.Equals(PasscodeSecurity.decPasscode(user.Passcode)))
                {
                    Session["User"] = user;
                    if (user.IsAdmin == true)
                    {
                        return RedirectToAction("IndexAdmin", "Home");
                    }
                    else if (user.IsAdmin == false)
                    {
                        return RedirectToAction("IndexUser", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", @Lab07.Languages.Lg.WrongPassword);
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            if (Session["User"] != null)
            {
                Session.Clear();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}