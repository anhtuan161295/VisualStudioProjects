using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab05.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("connProduct")
        {
        }

        public DbSet<Product> ProductList { get; set; }
    }
}