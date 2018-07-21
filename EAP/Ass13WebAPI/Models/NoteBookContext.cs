using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Ass13WebAPI.Models
{
    public class NoteBookContext : DbContext
    {
        public NoteBookContext() : base("name=Ass13Conn")
        {
        }

        public DbSet<NoteBook> NoteBookList { get; set; }
    }
}