using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab06.Models
{
    public class SaleDBContext : DbContext
    {
        public SaleDBContext() : base("ComputerConn")
        {
        }

        public DbSet<User> UserList { get; set; }
        public DbSet<Computer> ComputerList { get; set; }
    }
}