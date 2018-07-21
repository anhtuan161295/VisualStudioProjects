using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab03.Models
{
    //[Table("tbStudent")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Student name from 1 to 30 characters")]
        public string Name { get; set; }

        [Required]
        [Range(18, 60, ErrorMessage = "Age from 18 to 60")]
        public int Age { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Address from 2 to 20 characters")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}