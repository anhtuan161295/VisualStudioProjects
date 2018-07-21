using Lab04MVCWebRole.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab04MVCWebRole.Controllers
{
    public class PublishersController : Controller
    {
        ServiceReference1.Service1Client sc = new Service1Client();

        // GET: Publishers
        public ActionResult Index()
        {
            return View(sc.GetPublishers());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Publisher publisher)
        {
            try
            {
                sc.addPublisher(publisher);
                ModelState.AddModelError("", "Add publisher completed");
            }
            catch (Exception)
            {
            }
            return View();
        }
    }
}