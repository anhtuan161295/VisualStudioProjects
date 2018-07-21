using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace Module03.model
{
    public class Car : INotifyPropertyChanged
    {
        private string make;
        private string model;
        private string yearOfRes;
        private string addOn;
        private double renPerDay;

        //public Car(string make)
        //{
        //   this.make = make;
        //}
        public string Make
        {
            get { return make; }
            set { make = value; }
        }



        public string Model
        {
            get { return model; }
            set { model = value; RaisePropertyChanged("Model"); }
        }



        public string YearOfRes
        {
            get { return yearOfRes; }
            set { yearOfRes = value; RaisePropertyChanged("YearOfRes"); }
        }



        public string AddOn
        {
            get { return addOn; }
            set { addOn = value; RaisePropertyChanged("AddOn"); }
        }



        public double RenPerDay
        {
            get { return renPerDay; }
            set { renPerDay = value; RaisePropertyChanged("RenPerDay"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string massage)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(massage));
            }
        }



        public class CarDataSource
        {
            public static ObservableCollection<Car> cList = new ObservableCollection<Car>
        {
            new Car{Make="Toyota", Model="Camry2012", AddOn="Wifi", YearOfRes="1/1/2012", RenPerDay=50},
            new Car{Make="Honda", Model="Civic2012", AddOn="Wifi", YearOfRes="11/11/2012", RenPerDay=50}
        };
        }
    }
}

