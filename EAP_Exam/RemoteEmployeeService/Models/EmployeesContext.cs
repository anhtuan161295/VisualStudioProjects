using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RemoteEmployeeService.Models
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext() : base("name=EmpConn")
        {
        }

        public DbSet<Employees> EmployeeList { get; set; }
    }
}