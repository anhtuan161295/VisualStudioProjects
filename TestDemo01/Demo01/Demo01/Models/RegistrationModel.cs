using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo01.Models
{
    public class RegistrationModel
    {
        [Key]
        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Username")]
        [Remote("CheckUserNameExist", "Registrations", HttpMethod = "POST", ErrorMessage = "Username already exists!")]
        public string UserName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        [DataType(DataType.Password)]
        public string Passcode { get; set; }

        [Required]
        [Range(18, 60)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        [StringLength(250)]
        [DataType(DataType.EmailAddress)]
        [Remote("CheckEmailExist", "Registrations", HttpMethod = "POST", ErrorMessage = "Email already exists!")]
        public string Email { get; set; }
    }
}