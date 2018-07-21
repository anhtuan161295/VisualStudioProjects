using Lab04MVCWebRole.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab04MVCWebRole.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.Service1Client sc = new Service1Client();

        // GET: Home
        public ActionResult Index()
        {
            return View(sc.GetBookList());
        }
    }
}