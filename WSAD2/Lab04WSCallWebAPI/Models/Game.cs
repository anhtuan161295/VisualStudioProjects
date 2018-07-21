using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab04WSCallWebAPI.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ReleaseOfYear { get; set; }
    }
}