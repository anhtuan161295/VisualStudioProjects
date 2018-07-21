using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Lab02WebAPI.Models
{
    public class NewsContext : DbContext
    {
        public NewsContext() : base("name=NewsConn")
        {
        }

        public DbSet<News> NewsList { get; set; }
    }
}