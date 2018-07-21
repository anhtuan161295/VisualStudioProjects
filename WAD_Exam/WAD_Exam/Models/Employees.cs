using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WAD_Exam.Models
{
    public class Employees
    {
        [Key]
        [Display(Name = "Employee Id")]
        public int EmpID { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime EmpDoB { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        [StringLength(30)]
        public string EmpName { get; set; }

        [Required]
        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        [StringLength(30)]
        public string EmpAddress { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30)]
        public string EmpEmail { get; set; }
    }
}