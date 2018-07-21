using Lab07.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Lab07.Models
{
    [Table("tblUser")]
    public class User
    {
        [Key]
        [Display(Name = "Username", ResourceType = typeof(Lab07.Languages.Lg))]
        public string Username { get; set; }

        [Required]
        [Display(Name = "FirstName", ResourceType = typeof(Lab07.Languages.Lg))]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName", ResourceType = typeof(Lab07.Languages.Lg))]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Passcode", ResourceType = typeof(Lab07.Languages.Lg))]
        [DataType(DataType.Password)]
        public string Passcode { get; set; }

        [Required]
        [Display(Name = "Address", ResourceType = typeof(Lab07.Languages.Lg))]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class UserContext : DbContext
    {
        public UserContext() : base("name=ConnUser")
        {
        }

        public DbSet<User> UserList { get; set; }
    }
}