using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCWebRole.Models
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(30)]
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(30)]
        //[DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        [StringLength(30)]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}