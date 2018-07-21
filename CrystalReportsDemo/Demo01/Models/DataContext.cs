using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Demo01.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=MyConnectionString")
        {
        }

        public DbSet<Customer> CustomerList { get; set; }
        public DbSet<Item> ItemList { get; set; }
    }
}