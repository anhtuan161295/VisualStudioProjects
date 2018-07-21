using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab02WebClient.Models
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsId { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [StringLength(550)]
        public string ShortContent { get; set; }

        [Required]
        [StringLength(1150)]
        public string Content { get; set; }

        [StringLength(350)]
        public string Photo { get; set; }

        public string DateOfPublisher
        {
            get { return DateTime.Now.ToShortDateString(); }
        }
    }
}