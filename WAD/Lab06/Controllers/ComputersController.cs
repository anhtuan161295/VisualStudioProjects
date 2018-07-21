using Lab06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.WebPages;

namespace Lab06.Controllers
{
    public class ComputersController : Controller
    {
        SaleDBContext db = new SaleDBContext();

        // GET: Computers
        [OutputCache(Duration = 1024, Location = OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            return View(db.ComputerList.ToList());
        }

        [HttpPost]
        public ActionResult Index(string numFrom, string numTo)
        {
            var model = db.ComputerList.ToList();
            if (!numFrom.IsInt() || !numTo.IsInt())
            {
                ModelState.AddModelError("", "From Price and To Price must be a number");
            }
            else
            {
                var min = int.Parse(numFrom);
                var max = int.Parse(numTo);
                if (min < 0)
                {
                    ModelState.AddModelError("", "From Price must be greater than 0");
                }
                else if (max < 0)
                {
                    ModelState.AddModelError("", "Max Price must be greater than 0");
                }
                else if (min > max)
                {
                    ModelState.AddModelError("", "From price can't be greater than To price");
                }
                else
                {
                    model = (from u in db.ComputerList
                             where u.Price >= min && u.Price <= max
                             select u).ToList();
                }
            }

            return View(model);
        }

        public ActionResult Create()
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Index", "Logins");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(Computer newComputer, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                newComputer.Photo = "/Images/" + System.IO.Path.GetFileName(file.FileName);
                db.ComputerList.Add(newComputer);
                db.SaveChanges();
                ModelState.AddModelError("", "Add computer completed!");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            Computer computerCache = HttpContext.Cache["compCache"] as Computer;
            if (computerCache != null)
            {
                ViewBag.Msg = "Read computer from cache";
            }
            else
            {
                computerCache = db.ComputerList.Find(id);
                HttpContext.Cache.Insert("compCache", computerCache, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero);
                ViewBag.Msg = "Read computer from database";
            }
            return View(computerCache);
        }
    }
}