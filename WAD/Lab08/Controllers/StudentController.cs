using DynamicJson;
using DynamicJson.Extensions;
using Lab08.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace Lab08.Controllers
{
    public class StudentController : Controller
    {
        SchoolContext db = new SchoolContext();

        // GET: Student
        public ActionResult Index()
        {
            //ViewBag.CourseInfo = db.CourseList;

            var res = from s in db.StudentList
                      join c in db.CourseList on s.CourseId equals c.CourseId
                      select new
                      {
                          s.StudentId,
                          s.StudentName,
                          s.Address,
                          s.Email,
                          c.CourseName,
                          c.Duration
                      };

            var model = (object)res.JsSerialize();

            //ViewBag.csList = model.ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            TempData["sList"] = new SelectList(db.CourseList, "CourseId", "CourseName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Student newStudent)
        {
            TempData["sList"] = new SelectList(db.CourseList, "CourseId", "CourseName");

            if (ModelState.IsValid)
            {
                db.StudentList.Add(newStudent);
                db.SaveChanges();
                ModelState.AddModelError("", "Create student completed");
            }
            return View();
        }

        public ActionResult EditOrDelete(int id)
        {
            TempData["sList"] = new SelectList(db.CourseList, "CourseId", "CourseName");

            return View(db.StudentList.Find(id));
        }

        [HttpPost]
        public ActionResult EditOrDelete(Student editStudent, string command)
        {
            TempData["sList"] = new SelectList(db.CourseList, "CourseId", "CourseName");

            if (ModelState.IsValid)
            {
                if (command == "Save")
                {
                    db.Entry(editStudent).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Student");
                }
                else if (command == "Delete")
                {
                    db.Entry(editStudent).State = EntityState.Deleted;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Student");
                }
            }
            return View();
        }
    }
}