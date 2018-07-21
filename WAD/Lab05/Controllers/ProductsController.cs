using Lab05.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab05.Controllers
{
    public class ProductsController : Controller
    {
        ProductContext db = new ProductContext();

        // GET: Products
        public ActionResult Index(string name)
        {
            var model = db.ProductList.ToList();
            if (!string.IsNullOrEmpty(name))
            {
                model = db.ProductList.Where(p => p.ProductName.Contains(name)).ToList();
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            return View(db.ProductList.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    product.Photo = "/Images/" + System.IO.Path.GetFileName(file.FileName);
                }

                db.ProductList.Add(product);
                db.SaveChanges();
                ModelState.AddModelError("", "Save product completed");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(db.ProductList.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase file)
        {
            var oldPhoto = product.Photo;
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        product.Photo = "/Images/" + System.IO.Path.GetFileName(file.FileName);
                    }
                    else
                    {
                        product.Photo = oldPhoto;
                    }

                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Products");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            return View(db.ProductList.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.ProductList.Remove(db.ProductList.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}