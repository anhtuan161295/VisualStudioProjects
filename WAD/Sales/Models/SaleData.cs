using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sales.Models
{
    public class SaleData : DbContext
    {
        public SaleData() : base("SaleConn")
        {
        }

        public DbSet<Item> ItemList { get; set; }
    }
}