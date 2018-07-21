using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemo01.Models;

namespace TestDemo01.Controllers
{
    public class RegistersController : Controller
    {
        DataContext db = new DataContext();

        // GET: Registers
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public JsonResult Register(string regUsername, string regPassword)
        {
            var user = new User()
            {
                Username = regUsername,
                Password = regPassword
            };
            db.Entry(user).State = EntityState.Added;
            db.SaveChanges();
            return Json("Register success", JsonRequestBehavior.AllowGet);
        }
    }
}