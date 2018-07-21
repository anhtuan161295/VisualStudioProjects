using Lab03.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab03.Controllers
{
    public class StudentsController : Controller
    {
        public static StudentContext db = new StudentContext();

        // GET: Students
        public ActionResult Index()
        {
            var res = db.StudentList.Select(s => new
            {
                Name = s.Name,
                Address = s.Address
            });

            var model = from s in db.StudentList
                        orderby s.Age ascending
                        //where s.Age > 20
                        select s;
            return View(model);
        }

        public ActionResult Details(int id)
        {
            return View(db.StudentList.SingleOrDefault(s => s.Id.Equals(id)));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //db.StudentList.Add(student);
                    db.Entry(student).State = EntityState.Added;
                    db.SaveChanges();
                    ModelState.AddModelError("", "Add student completed!");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Fail!");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(db.StudentList.SingleOrDefault(s => s.Id.Equals(id)));
        }

        [HttpPost]
        public ActionResult Edit(Student editStudent)
        {
            var std = db.StudentList.SingleOrDefault(s => s.Id.Equals(editStudent.Id));
            try
            {
                if (ModelState.IsValid)
                {
                    std.Name = editStudent.Name;
                    std.Age = editStudent.Age;
                    std.Address = editStudent.Address;
                    std.Email = editStudent.Email;
                    db.SaveChanges();
                    ModelState.AddModelError("", "Update student completed!");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Fail!");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var std = db.StudentList.SingleOrDefault(s => s.Id.Equals(id));

            try
            {
                //db.StudentList.Remove(std);
                db.Entry(std).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index", "Students");
                //ModelState.AddModelError("", "Delete student completed!");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Fail!");
            }
            return View();
            //return View(db.StudentList.SingleOrDefault(s => s.Id.Equals(id)));
        }

        //[HttpPost]
        //[ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var std = db.StudentList.SingleOrDefault(s => s.Id.Equals(id));

        //    try
        //    {
        //        db.StudentList.Remove(std);
        //        db.SaveChanges();
        //        return RedirectToAction("Index", "Students");
        //        //ModelState.AddModelError("", "Delete student completed!");
        //    }
        //    catch (Exception)
        //    {
        //        ModelState.AddModelError("", "Fail!");
        //    }
        //    return View();
        //}
    }
}