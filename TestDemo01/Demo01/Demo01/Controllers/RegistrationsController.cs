using Demo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo01.Controllers
{
    public class RegistrationsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Registrations
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // Create
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel newUser)
        {
            return View();
        }

        // Check if username exists
        [HttpPost]
        public JsonResult CheckUserNameExist(string username)
        {
            var user = db.Users.Find(username);

            return Json(user == null);
        }

        // Check if email exists
        [HttpPost]
        public JsonResult CheckEmailExist(string email)
        {
            var user = db.Users.Find(email);

            return Json(user == null);
        }
    }
}