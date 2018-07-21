using RemoteEmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RemoteEmployeeService.Controllers
{
    public class EmployeesController : ApiController
    {
        EmployeesContext db = new EmployeesContext();

        public IEnumerable<Employees> GetEmployeeList()
        {
            return db.EmployeeList;
        }

        public Employees GetEmployee(int id)
        {
            var emp = db.EmployeeList.Find(id);
            return emp;
        }

        public IHttpActionResult PostEmployee(Employees newEmployee)
        {
            db.EmployeeList.Add(newEmployee);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult PutEmployee(Employees editEmployee)
        {
            var emp = db.EmployeeList.Find(editEmployee.EmployeeID);
            if (emp != null)
            {
                emp.EmployeeName = editEmployee.EmployeeName;
                emp.Address = editEmployee.Address;
                emp.Email = editEmployee.Email;

                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        //public IHttpActionResult DeleteEmployee(int id)
        //{
        //    var emp = db.EmployeeList.Find(id);
        //    if (emp != null)
        //    {
        //        db.EmployeeList.Remove(emp);
        //        db.SaveChanges();
        //        return Ok();
        //    }
        //    return NotFound();
        //}
    }
}