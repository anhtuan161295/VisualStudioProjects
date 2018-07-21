using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Lab04_Assignment05.Models
{
    [Table]
    class Game
    {
        private int _id;
        private string _title;
        private DateTime _yearOfRelease;
        private double _price;

        [Column(IsPrimaryKey = true)]
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        [Column(CanBeNull = false)]
        public string Title
        {
            get { return _title; }
            set
            {
                if (value.Length < 3)
                {
                    throw new Exception("Title length must be larger than 3 characters");
                }
                else
                {
                    _title = value;
                }
            }
        } // length >=3

        [Column(CanBeNull = false)]
        public DateTime YearOfRelease
        {
            get { return _yearOfRelease; }
            set
            {
                if (value.Year < 2000 || value.Year > 2016)
                {
                    throw new Exception("Year must be from 2000 to 2016");
                }
                else
                {
                    _yearOfRelease = value;
                }
            }
        } // 2000-2016

        [Column(CanBeNull = false)]
        public double Price
        {
            get { return _price; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Price must be larger than 0");
                }
                else
                {
                    _price = value;
                }
            }
        } // >0
    }
}