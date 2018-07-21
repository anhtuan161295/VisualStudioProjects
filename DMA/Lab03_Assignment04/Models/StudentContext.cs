using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_Assignment04.Models
{
    class StudentContext
    {
        public static ObservableCollection<Student> sList = new ObservableCollection<Student>()
        {
            new Student(){Id = 1, Name = "Nguyen Van A", Address = "CMT1", DateOfBirth = "12/07/2000", Phone = "0123321121", Email = "nguyenvana@gmail.com"},
            new Student(){Id = 2, Name = "Nguyen Van B", Address = "CMT2", DateOfBirth = "12/07/2001", Phone = "0123321122", Email = "nguyenvanb@gmail.com"},
            new Student(){Id = 3, Name = "Nguyen Van C", Address = "CMT3", DateOfBirth = "12/07/2002", Phone = "0123321123", Email = "nguyenvanc@gmail.com"},
            new Student(){Id = 4, Name = "Nguyen Van D", Address = "CMT4", DateOfBirth = "12/07/2003", Phone = "0123321124", Email = "nguyenvand@gmail.com"}
        };
    }
}