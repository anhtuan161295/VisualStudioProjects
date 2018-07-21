using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab04WebAPIServices.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ReleaseOfYear { get; set; }
    }
}