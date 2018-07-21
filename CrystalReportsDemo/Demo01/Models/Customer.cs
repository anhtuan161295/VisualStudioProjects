using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo01.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public string CCode { get; set; }

        public string CName { get; set; }
        public string CAddress { get; set; }
        public string CPhone { get; set; }
    }
}