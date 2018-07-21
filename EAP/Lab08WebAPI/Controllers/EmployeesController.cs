using Lab08WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab08WebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        EmployeeContext db = new EmployeeContext();

        public IQueryable<Employee> GetEmployees()
        {
            return db.EmployeeList;
        }

        public IHttpActionResult PostEmployee(Employee newEmployee)
        {
            db.EmployeeList.Add(newEmployee);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult PutEmployee(Employee editEmployee)
        {
            var emp = db.EmployeeList.Find(editEmployee.Id);
            if (emp != null)
            {
                emp.EmployeeName = editEmployee.EmployeeName;
                emp.Age = editEmployee.Age;
                emp.Address = editEmployee.Address;

                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
            }
            else if (emp == null)
            {
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult DeleteEmployee(int id)
        {
            var emp = db.EmployeeList.Find(id);
            if (emp != null)
            {
                db.EmployeeList.Remove(emp);
                db.SaveChanges();
            }
            else if (emp == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}