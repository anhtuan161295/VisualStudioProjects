using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemo01.Models;

namespace TestDemo01.Controllers
{
    public class LoginsController : Controller
    {
        DataContext db = new DataContext();
        // GET: Logins
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public JsonResult CheckLogin(string txtUsername, string txtPassword)
        {
            var user = db.UserList.SingleOrDefault(u => u.Username.Equals(txtUsername));
            if (user == null)
            {
                return Json("User not found", JsonRequestBehavior.AllowGet);
            }
            if (user != null)
            {
                if (txtPassword.Equals(user.Password))
                {
                    Session["User"] = user;
                    return Json("Login success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Wrong password", JsonRequestBehavior.AllowGet);
                }
            }
            //return nothing
            return Json(new EmptyResult());
        }

        public ActionResult Logout()
        {
            if (Session["User"] != null)
            {
                Session.Abandon();
            }
            return RedirectToAction("Index", "Users");
        }
    }
}