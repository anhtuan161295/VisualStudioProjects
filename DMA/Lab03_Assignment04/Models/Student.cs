using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab03_Assignment04.Models
{
    class Student : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _address;
        private string _dateOfBirth;
        private string _phone;
        private string _email;

        public int Id
        {
            get { return _id; }
            set
            {
                if (Regex.IsMatch(value.ToString(), "^\\d+$") == true)
                {
                    _id = value; OnPropertyChanged("Id");
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length >= 3)
                {
                    _name = value; OnPropertyChanged("Name");
                }
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (value.Length >= 2 & value.Length <= 30)
                {
                    _address = value; OnPropertyChanged("Address");
                }
            }
        }

        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; OnPropertyChanged("DateOfBirth"); }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (Regex.IsMatch(value, "(\\+84|0)\\d{9,10}") == true)
                {
                    _phone = value; OnPropertyChanged("Phone");
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (Regex.IsMatch(value, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?") == true)
                {
                    _email = value; OnPropertyChanged("Email");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}