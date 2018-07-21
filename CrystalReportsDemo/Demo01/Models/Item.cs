using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo01.Models
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public string ICode { get; set; }

        public string ItemName { get; set; }
        public int Rate { get; set; }
    }
}