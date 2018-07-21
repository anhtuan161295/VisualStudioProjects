using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03.Models
{
    class EmployeeContext
    {
        public static ObservableCollection<Employee> eList = new ObservableCollection<Employee>
        {
            new Employee{EmployeeId = "E101", FullName = "Olex Obama", UserName = "Obama", Passcode = CryptographyLibrary.Encrypt("123"), Address = "US", Email = "Obama@outlook.com", IsAdmin = true, imgPath = "h1.png"},
            new Employee{EmployeeId = "E102", FullName = "Olex Obama", UserName = "Obama1", Passcode = CryptographyLibrary.Encrypt("123"), Address = "US", Email = "Obama@outlook.com", IsAdmin = false, imgPath = "h2.png"}
        };
    }
}