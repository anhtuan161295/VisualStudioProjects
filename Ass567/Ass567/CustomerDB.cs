using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass567
{
    class CustomerDB
    {
        public static ObservableCollection<Customer> customerList = new ObservableCollection<Customer>
        {
            new Customer{Fullname = "Nguyen Van A", Username = "admin", Password = "admin", Address = "CMT8", Phone = "0914678876", Email = "nguyenvana@gmail.com", IsAdmin = true},
            new Customer{Fullname = "Le Van B", Username = "user", Password = "user", Address = "Truong Chinh", Phone = "0914678843", Email = "levanb@gmail.com", IsAdmin = false},
        };
    }
}