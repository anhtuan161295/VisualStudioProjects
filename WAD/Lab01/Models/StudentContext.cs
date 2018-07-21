using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Lab01.Models
{
    public class StudentContext
    {
        public ObservableCollection<Student> sList = new ObservableCollection<Student>()
        {
            new Student(){StudentId = 1, StudentName = "Obama", Address = "US", Email = "Obama@outlook.com"},
            new Student(){StudentId = 2, StudentName = "Nghi", Address = "VN", Email = "Nghi@gmail.com"}
        };
    }
}