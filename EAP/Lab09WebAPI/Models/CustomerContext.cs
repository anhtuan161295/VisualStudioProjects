using CustomerLib;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Lab09WebAPI.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("name=Lab9Conn")
        {
        }

        public DbSet<Customer> CustomerList { get; set; }
    }
}