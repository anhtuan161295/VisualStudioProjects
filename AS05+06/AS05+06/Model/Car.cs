using System.ComponentModel;

namespace AS05_06.Model
{
    //Implement Interface INotifyPropertyChanged chủ yếu là hỗ trợ Data Binding OneWay,TwoWay.
    //Mục đích là thông báo để khi update mấy cái thuộc tính (properties) của class
    class Car : INotifyPropertyChanged
    {
        private string make;

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; RaisePropertyChanged("Model"); }
        }

        private string yearOfReg;

        public string YearOfReg
        {
            get { return yearOfReg; }
            set { yearOfReg = value; RaisePropertyChanged("YearOfReg"); }
        }

        private string addon;

        public string Addon
        {
            get { return addon; }
            set { addon = value; RaisePropertyChanged("Addon"); }
        }

        private double rentPerDay;

        public double RentPerDay
        {
            get { return rentPerDay; }
            set { rentPerDay = value; RaisePropertyChanged("RentPerDay"); }
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
}