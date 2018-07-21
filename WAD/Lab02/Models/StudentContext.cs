using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Lab02.Models
{
    public class StudentContext
    {
        public static ObservableCollection<Student> sList = new ObservableCollection<Student>()
        {
            new Student(){StudentId = 1, StudentName = "Obama", Address = "US", Email = "Obama@gmail.com"}
        };
    }
}