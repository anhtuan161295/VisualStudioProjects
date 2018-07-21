using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab07WebAPIRole.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string YearOfRelease { get; set; }
    }

    public class AlbumContext : DbContext
    {
        public AlbumContext() : base("name=AlbumConn")
        {
        }

        public DbSet<Album> AlbumList { get; set; }
    }
}