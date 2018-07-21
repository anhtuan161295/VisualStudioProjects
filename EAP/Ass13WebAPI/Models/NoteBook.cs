using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ass13WebAPI.Models
{
    [Table("NoteBook_tbl")]
    public class NoteBook
    {
        [Key]
        [StringLength(20)]
        public string NoteBookId { get; set; }

        [StringLength(20)]
        public string NoteBookTitle { get; set; }

        public int NoteBookPrice { get; set; }
        public bool Wifi { get; set; }
    }
}