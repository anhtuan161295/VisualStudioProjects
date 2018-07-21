using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace LabFinalWebAPI.Models
{
    public class DoctorContext : DbContext
    {
        public DoctorContext() : base("name=DoctorConn")
        {
        }

        public DbSet<Doctor> DoctorList { get; set; }
    }
}