using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Demo01.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataConn")
        {
        }

        public System.Data.Entity.DbSet<Demo01.Models.User> Users { get; set; }

        //public System.Data.Entity.DbSet<Demo01.Models.LoginModel> LoginModels { get; set; }

        //public System.Data.Entity.DbSet<Demo01.Models.RegistrationModel> RegistrationModels { get; set; }
    }
}