using Lab01WebRole.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01WebRole.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.Service1Client sc = new Service1Client();

        // GET: Home
        public ActionResult Index()
        {
            return View(sc.displayAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ServiceReference1.Patient newPatient)
        {
            try
            {
                sc.createPatient(newPatient);
                ModelState.AddModelError("", "Add patient completed");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            return View(sc.detailsPatient(id));
        }

        public ActionResult Edit(int id)
        {
            return View(sc.detailsPatient(id));
        }

        [HttpPost]
        public ActionResult Edit(Patient editPatient)
        {
            try
            {
                sc.editPatient(editPatient);
                ModelState.AddModelError("", "Update patient completed");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            return View(sc.detailsPatient(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            sc.deletePatient(id);
            return RedirectToAction("Index", "Home");
        }
    }
}