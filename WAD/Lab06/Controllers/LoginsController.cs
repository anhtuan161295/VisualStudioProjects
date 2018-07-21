using Lab06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab06.Controllers
{
    public class LoginsController : Controller
    {
        SaleDBContext db = new SaleDBContext();

        // GET: Logins
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User userLog)
        {
            var user = db.UserList.SingleOrDefault(u => u.UserName.Equals(userLog.UserName));
            if (user == null)
            {
                ModelState.AddModelError("", "User not found!");
            }
            else
            {
                Session["uname"] = user.UserName;
                if (userLog.Passcode.Equals(PasscodeSecurity.decPasscode(user.Passcode)))
                {
                    if (user.Roles == "Admin")
                    {
                        return RedirectToAction("Create", "Computers");
                    }
                    else if (user.Roles == "User")
                    {
                        return RedirectToAction("Index", "Computers");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid passcode!");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.RedirectToLoginPage();
            if (Session["uname"] != null)
            {
                Session["uname"] = null;
                Session.Abandon();
            }
            return RedirectToAction("Index", "Logins");
        }
    }
}