using Lab02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab02.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            return View(StudentContext.sList);
        }

        public ActionResult Details(int id)
        {
            return View(StudentContext.sList.SingleOrDefault(s => s.StudentId.Equals(id)));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student newStudent)
        {
            Student std = StudentContext.sList.SingleOrDefault(s => s.StudentId.Equals(newStudent.StudentId));
            try
            {
                if (std == null)
                {
                    StudentContext.sList.Add(newStudent);
                    ViewBag.Msg = "Add student completed";
                }
                else
                {
                    ViewBag.Msg = "Student existing!";
                }
            }
            catch (Exception)
            {
                ViewBag.Msg = "Error";
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(StudentContext.sList.SingleOrDefault(s => s.StudentId.Equals(id)));
        }

        [HttpPost]
        public ActionResult Edit(Student editStudent)
        {
            var std = StudentContext.sList.SingleOrDefault(s => s.StudentId.Equals(editStudent.StudentId));
            if (std != null)
            {
                std.StudentName = editStudent.StudentName;
                std.Address = editStudent.Address;
                std.Email = editStudent.Email;
            }
            ViewBag.Msg = "Update Student Completed";
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View(StudentContext.sList.SingleOrDefault(s => s.StudentId.Equals(id)));
        }

        //[HttpPost]
        //[ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Student std = StudentContext.sList.SingleOrDefault(s => s.StudentId.Equals(id));
        //    StudentContext.sList.Remove(std);
        //    return RedirectToAction("Index", "Students");

        //    //return View();
        //}

        [HttpPost]
        public ActionResult Delete(Student delStudent)
        {
            var std = StudentContext.sList.SingleOrDefault(s => s.StudentId.Equals(delStudent.StudentId));
            if (std != null)
            {
                StudentContext.sList.Remove(delStudent);
                return RedirectToAction("Index", "Students");
            }
            return View();
        }
    }
}