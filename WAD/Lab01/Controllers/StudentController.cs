using Lab01.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public static StudentContext db = new StudentContext();

        [HttpGet]
        public ActionResult Index()
        {
            //var model = db.sList.ToList();
            return View(db.sList.ToList());

            //return View();
        }

        //[HttpGet]
        //public ActionResult DeleteWithConfirm()
        //{
        //    return View();
        //}

        public static int IdToDelete = 0;

        [HttpGet]
        public ActionResult DeleteWithConfirm(int id) //Có xác nhận yes/no
        {
            var model = db.sList.SingleOrDefault(s => s.StudentId.Equals(id));
            IdToDelete = id;
            return View(model);
        }

        //[HttpGet]
        //public ActionResult DeleteWithoutConfirm()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult DeleteWithoutConfirm(int id) // Ko xác nhận yes/no
        {
            if (db.sList.Count > 0)
            {
                var student = db.sList.SingleOrDefault(s => s.StudentId == id);
                db.sList.Remove(student);
                Debug.WriteLine(db.sList.Count);

                return RedirectToAction("Index", "Student");
            }

            return View();
        }

        [HttpPost]
        public ActionResult DeleteWithConfirm1() // Ko xác nhận yes/no
        {
            Debug.WriteLine(IdToDelete);
            if (db.sList.Count > 0)
            {
                var ss = db.sList.SingleOrDefault(s => s.StudentId.Equals(IdToDelete));
                //Debug.WriteLine(db.sList.Count);
                //Debug.WriteLine(ss.StudentId + ss.StudentName);
                db.sList.Remove(ss);

                return RedirectToAction("Index", "Student");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            //return View(db.sList.SingleOrDefault(s => s.StudentId.Equals(studentId)));
            var model = db.sList.SingleOrDefault(s => s.StudentId.Equals(id));
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            var model = db.sList.SingleOrDefault(s => s.StudentId.Equals(student.StudentId));
            try
            {
                if (model == null)//Ko tìm thấy student thì tạo
                {
                    //var ss = new Student() { StudentId = student.StudentId, StudentName = student.StudentName, Address = student.Address, Email = student.Email };
                    db.sList.Add(student);
                    //Debug.WriteLine("Add completed");
                    //Debug.WriteLine(db.sList.Count);
                    //Debug.WriteLine(student.StudentId + student.StudentName);
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    ModelState.AddModelError("", "Student existing!");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error");
            }
            //return RedirectToAction("Index", "Student", db.sList.ToList());

            return View();
        }
    }
}