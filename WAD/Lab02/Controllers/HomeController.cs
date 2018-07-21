using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab02.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //ViewBag.currentTime = DateTime.Now;
            //ViewData["Msg"] = "Hello MVC 5!";
            return RedirectToAction("Index", "Students");
            //return View();
        }
    }
}