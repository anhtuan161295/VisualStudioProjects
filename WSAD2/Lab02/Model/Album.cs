using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Model
{
    class Album
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }
    }

    class AlbumContext
    {
        public static ObservableCollection<Album> aList = new ObservableCollection<Album>
        {
            new Album{Title = "Chieu Xuan", Genre = "Dong Que", Year = "2000"},
            new Album{Title = "Tinh Yeu", Genre = "Nhac Tre", Year = "2001"},
            new Album{Title = "Tinh Ca", Genre = "Nhac Tre", Year = "2002"}
        };
    }
}