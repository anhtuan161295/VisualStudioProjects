using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace TestDemo01.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("UserDB")
        {
        }

        public DbSet<User> UserList { get; set; }
    }
}