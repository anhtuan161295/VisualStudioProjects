using Demo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo01.Controllers
{
    public class CustomersController : Controller
    {
        public static DataContext db = new DataContext();

        // GET: Customers
        public ActionResult Index()
        {
            var model = from s in db.CustomerList
                        orderby s.CCode ascending
                        select s
                ;
            return View(model);
        }
    }
}