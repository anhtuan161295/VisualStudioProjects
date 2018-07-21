using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Demo01.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo01.Controllers
{
    public class HomeController : Controller
    {
        public static DataContext db = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Items");
            //return View();
        }

        //public ActionResult exportProducts()
        //{
        //    ReportDocument rd = new ListOfProducts();

        //    Stream stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
        //    return File(stream, "application/pdf");
        //}

        //public ActionResult exportCustomers()
        //{
        //    ReportDocument rd = new ListOfCustomers();

        //    Stream stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
        //    return File(stream, "application/pdf");
        //}

        //public ActionResult exportOrders()
        //{
        //    ReportDocument rd = new ListOfOrders();

        //    Stream stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
        //    return File(stream, "application/pdf");
        //}
    }
}