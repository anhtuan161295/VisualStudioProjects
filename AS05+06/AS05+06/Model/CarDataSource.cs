using System.Collections.ObjectModel;

namespace AS05_06.Model
{
    class CarDataSource
    {
        public static ObservableCollection<Car> list = new ObservableCollection<Car>()
        {
            new Car {Make = "Toyota", Model = "Camry2012", YearOfReg = "1/1/2012", Addon = "Wifi", RentPerDay = 30},
            new Car {Make = "HonDa", Model = "Cevic2014", YearOfReg = "11/11/2014", Addon = "Wifi", RentPerDay = 40}
        };
    }
}