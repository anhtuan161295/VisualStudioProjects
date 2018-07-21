using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Models
{
    class GameContext
    {
        public static ObservableCollection<Game> gList = new ObservableCollection<Game>()
        {
            new Game(){_Id = 1, _Title = "AAA", _Genre = "hanh dong", _YearOfRelease = "2010", _Price = 1},
            new Game(){_Id = 2, _Title = "BBB", _Genre = "giai tri", _YearOfRelease = "2011", _Price = 2},
            new Game(){_Id = 3, _Title = "CCC", _Genre = "giai tri", _YearOfRelease = "2012", _Price = 3}
            //new Game(){_Id = 4, _Title = "D", _Genre = "AD", _YearOfRelease = "2013", _Price = 4}
        };
    }
}