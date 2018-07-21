using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Models
{
    class Game : INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged("Title"); }
        }

        private string genre;

        public string Genre
        {
            get { return genre; }
            set { genre = value; RaisePropertyChanged("Genre"); }
        }

        private string year;

        public string Year
        {
            get { return year; }
            set { year = value; RaisePropertyChanged("Year"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string message)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(message));
            }
        }
    }

    class GameModel
    {
        public static ObservableCollection<Game> gList = new ObservableCollection<Game>
        {
            new Game{Id = 1, Title = "Car", Genre = "Action", Year = "2010"}
        };
    }
}