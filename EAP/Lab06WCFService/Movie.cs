using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace Lab06WCFService
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Director { get; set; }
        public string YearOfRelease { get; set; }
    }

    public class MovieContext : DbContext
    {
        public MovieContext() : base("name=MovieConn")
        {
        }

        public DbSet<Movie> MovieList { get; set; }
    }
}