using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Demo01.Models;
using Demo01.Reports;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo01.Controllers
{
    public class ItemsController : Controller
    {
        public static DataContext db = new DataContext();
        public static List<Item> modelToExport = db.ItemList.ToList();

        // GET: Items
        //public ActionResult Index()
        //{
        //    var model = from s in db.ItemList
        //                orderby s.ICode ascending
        //                select s
        //        ;
        //    return View(model);
        //}

        public ActionResult Index(string sortOrder)
        {
            var model = from s in db.ItemList
                        select s
                ;
            ViewBag.currentSort = sortOrder;

            ViewBag.sortCode = sortOrder == "code_asc" ? "code_desc" : "code_asc";
            ViewBag.sortName = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewBag.sortRate = sortOrder == "rate_asc" ? "rate_desc" : "rate_asc";

            switch (sortOrder)
            {
                case "code_asc":
                    model = from s in db.ItemList orderby s.ICode ascending select s;
                    break;

                case "code_desc":
                    model = from s in db.ItemList orderby s.ICode descending select s;
                    break;

                case "name_asc":
                    model = from s in db.ItemList orderby s.ItemName ascending select s;
                    break;

                case "name_desc":
                    model = from s in db.ItemList orderby s.ItemName descending select s;
                    break;

                case "rate_asc":
                    model = from s in db.ItemList orderby s.Rate ascending select s;
                    break;

                case "rate_desc":
                    model = from s in db.ItemList orderby s.Rate descending select s;
                    break;

                default:
                    model = from s in db.ItemList orderby s.ICode ascending select s;
                    break;
            }
            modelToExport.Clear();
            modelToExport = model.ToList();
            return View(model.ToList());
        }

        [HttpPost]
        public ActionResult SearchItem(string txtSearch, string txtSearchType)
        {
            var model = db.ItemList.ToList();
            if (!string.IsNullOrEmpty(txtSearch))
            {
                if (txtSearchType == "ICode")
                {
                    model = db.ItemList.Where(u => u.ICode.Contains(txtSearch)).ToList();
                    if (model.Any() == false)
                    {
                        //ModelState.AddModelError("msgError", "Item not found");
                        return View("ItemNotFound");
                    }
                }
                if (txtSearchType == "ItemName")
                {
                    model = db.ItemList.Where(u => u.ItemName.Contains(txtSearch)).ToList();
                    if (model.Any() == false)
                    {
                        return View("ItemNotFound");
                    }
                }
                if (txtSearchType == "Rate")
                {
                    model = db.ItemList.Where(u => u.Rate.ToString().Contains(txtSearch)).ToList();
                    if (model.Any() == false)
                    {
                        return View("ItemNotFound");
                    }
                }
            }
            modelToExport.Clear();
            modelToExport = model;
            return View("Index", model);
        }

        public ActionResult Details(string id)
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
                return RedirectToAction("Index", "Items");
            }
            return View();
        }

        public ActionResult Edit(string id)
        {
            return View(db.ItemList.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Item editItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Items");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            return View(db.ItemList.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(Item delItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(delItem).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index", "Items");
            }
            return View();
        }

        public ActionResult exportItem()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Reports/ItemReport.rpt"));

            rd.SetDataSource(modelToExport);

            Stream stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }
    }
}