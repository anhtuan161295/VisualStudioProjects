using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSAD_Exam
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class CustomerData
    {
        public static ObservableCollection<Customer> CustomerList = new ObservableCollection<Customer>();
        //public static ObservableCollection<Customer> CustomerList = new ObservableCollection<Customer>
        //{
        //    new Customer{CustomerID = "C001", CustomerName = "tom", Address = "LA - USA", Phone = "090000000"},
        //    new Customer{CustomerID = "C002", CustomerName = "jerry", Address = "Cali - USA", Phone = "090110000"}
        //};
    }
}