using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab08.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required]
        [StringLength(30)]
        public string StudentName { get; set; }

        [Required]
        [StringLength(30)]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        public int CourseId { get; set; }
    }
}