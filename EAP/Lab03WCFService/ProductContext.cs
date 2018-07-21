using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Lab03WCFService
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("name=Lab3Conn")
        {
        }

        public DbSet<Product> ProductList { get; set; }
    }
}