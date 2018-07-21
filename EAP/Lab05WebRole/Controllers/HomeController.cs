using Lab05WebRole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab05WebRole.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.GetStudents());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student newStudent)
        {
            newStudent.PartitionKey = Guid.NewGuid().ToString();
            newStudent.RowKey = newStudent.StudentId.ToString();
            db.AddStudent(newStudent);
            ModelState.AddModelError("", "Add student completed");
            return View();
        }

        public ActionResult Details(string partKey, string rowKey)
        {
            var std = db.DetailsStudent(partKey, rowKey);
            return View(std);
        }

        public ActionResult Edit(string partKey, string rowKey)
        {
            var std = db.DetailsStudent(partKey, rowKey);
            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(Student editStudent)
        {
            db.EditStudent(editStudent);
            ModelState.AddModelError("", "Update student completed");
            return View();
        }

        public ActionResult Delete(string partKey, string rowKey)
        {
            var std = db.DetailsStudent(partKey, rowKey);
            return View(std);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string partKey, string rowKey)
        {
            db.DeleteStudent(partKey, rowKey);
            return RedirectToAction("Index");
        }
    }
}