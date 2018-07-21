using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Models
{
    class Game
    {
        public int Id
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Genre
        {
            get;
            set;
        }

        public string Year
        {
            get;
            set;
        }
    }

    class GameContext
    {
        public static ObservableCollection<Game> gList = new ObservableCollection<Game>()
        {
            new Game{Id=1,Title="Car",Genre="Action",Year="2010"}
        };
    }
}