using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab08.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=SchoolABC")
        {
        }

        public DbSet<Course> CourseList { get; set; }
        public DbSet<Student> StudentList { get; set; }
    }
}