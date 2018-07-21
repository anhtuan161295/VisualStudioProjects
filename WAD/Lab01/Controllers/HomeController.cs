using Lab01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        StudentContext db = new StudentContext();

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Student");
        }
    }
}