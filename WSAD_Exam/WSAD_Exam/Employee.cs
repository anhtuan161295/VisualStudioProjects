using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSAD_Exam
{
    class Employee
    {
        public string EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }

    class EmployeeData
    {
        public static ObservableCollection<Employee> EmployeeList = new ObservableCollection<Employee>();
        //public static ObservableCollection<Employee> EmployeeList = new ObservableCollection<Employee>
        //{
        //    new Employee{EmployeeID = "Emp001", FullName = "Nguyen Van A", Address = "District 1, HCM City", Email = "anv@gmail.com"},
        //    new Employee{EmployeeID = "Emp002", FullName = "Nguyen Van B", Address = "District 2, HCM City", Email = "bnv@gmail.com"},
        //    new Employee{EmployeeID = "Emp003", FullName = "Nguyen Van C", Address = "District 3, HCM City", Email = "cnv@gmail.com"},
        //    new Employee{EmployeeID = "Emp004", FullName = "Nguyen Van D", Address = "District 4, HCM City", Email = "dnv@gmail.com"},
        //    new Employee{EmployeeID = "Emp005", FullName = "Nguyen Van E", Address = "District 5, HCM City", Email = "env@gmail.com"},
        //};
    }
}