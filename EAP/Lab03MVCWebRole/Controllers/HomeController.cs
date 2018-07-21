using Lab03MVCWebRole.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab03MVCWebRole.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.Service1Client sc = new Service1Client();

        // GET: Home
        public ActionResult Index()
        {
            return View(sc.GetProductList());
        }

        public ActionResult Details(int id)
        {
            return View(sc.GetProductById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product newProduct)
        {
            sc.NewProduct(newProduct);
            return View();
        }
    }
}