using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace WAD_Exam.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("EmpConn")
        {
        }

        public DbSet<Employees> EmployeesList { get; set; }
    }
}