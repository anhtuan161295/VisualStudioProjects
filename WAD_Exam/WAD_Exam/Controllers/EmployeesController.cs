using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAD_Exam.Models;

namespace WAD_Exam.Controllers
{
    public class EmployeesController : Controller
    {
        DataContext db = new DataContext();

        // GET: Employees
        public ActionResult ViewEmployeeList()
        {
            return View(db.EmployeesList.ToList());
        }

        public ActionResult AddNewEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewEmployee(Employees newEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newEmployee).State = EntityState.Added;
                db.SaveChanges();
                ViewBag.Msg = "Employee added successful.";
            }
            return View();
        }

        public ActionResult EditOrDeleteEmployee(int id)
        {
            return View(db.EmployeesList.Find(id));
        }

        [HttpPost]
        public ActionResult EditOrDeleteEmployee(Employees newEmployee, string command)
        {
            if (command == "Save")
            {
                if (ModelState.IsValid)
                {
                    db.Entry(newEmployee).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Msg = "Employee updated successful.";
                }
            }
            if (command == "Remove")
            {
                db.Entry(newEmployee).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("ViewEmployeeList", "Employees");
                ViewBag.Msg = "Employee deleted successful.";
            }

            return View();
        }
    }
}