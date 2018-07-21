using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Lab08WebAPI.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeName { get; set; }

        [Required]
        [Range(14, 70)]
        public int Age { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }
    }

    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=Lab8Conn")
        {
        }

        public DbSet<Employee> EmployeeList { get; set; }
    }
}