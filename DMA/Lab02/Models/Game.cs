using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Lab02.Models
{
    class Game : INotifyPropertyChanged
    {
        private int id;

        public int _Id //phải là số
        {
            get { return id; }
            set
            {
                if (Regex.IsMatch(value.ToString(), "^\\d+$") == true)
                {
                    id = value; OnPropertyChanged("_Id");
                }
            }
        }

        private string title;

        public string _Title //> 3 kí tự
        {
            get { return title; }
            set
            {
                if (value.Length >= 3)
                {
                    title = value; OnPropertyChanged("_Title");
                }
            }
        }

        private string genre;

        public string _Genre //Hành động hoặc giải trí
        {
            get { return genre; }
            set
            {
                if (value == "hanh dong" || value == "giai tri")
                {
                    genre = value; OnPropertyChanged("_Genre");
                }
            }
        }

        private string year;

        public string _YearOfRelease
        {
            get { return year; }
            set
            {
                year = value; OnPropertyChanged("_YearOfRelease");
            }
        }

        private double price;

        public double _Price //> 0
        {
            get { return price; }
            set
            {
                if (value > 0)
                {
                    price = value; OnPropertyChanged("_Price");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}