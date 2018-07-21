using Sales.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sales.Controllers
{
    public class SalesController : Controller
    {
        SaleData db = new SaleData();

        // GET: Sales
        public ActionResult Index()
        {
            return View(db.ItemList.ToList());
        }

        public ActionResult Details(int id)
        {
            return View(db.ItemList.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Item newItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newItem).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index", "Sales");
            }
            return View();
        }

        public ActionResult EditOrDelete(int id)
        {
            return View(db.ItemList.Find(id));
        }

        [HttpPost]
        public ActionResult EditOrDelete(Item editItem, string command)
        {
            if (ModelState.IsValid)
            {
                if (command == "Save")
                {
                    db.Entry(editItem).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Sales");
                }
                else if (command == "Delete")
                {
                    db.Entry(editItem).State = EntityState.Deleted;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Sales");
                }
            }
            return View();
        }
    }
}