using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab03.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext()
            : base("name=StudentConn")
        {
        }

        public DbSet<Student> StudentList { get; set; }
    }
}