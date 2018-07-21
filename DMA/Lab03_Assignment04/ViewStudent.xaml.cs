using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Lab03_Assignment04
{
    public partial class ViewStudent : PhoneApplicationPage
    {
        public ViewStudent()
        {
            InitializeComponent();
            listboxStudent.ItemsSource = Models.StudentContext.sList;
        }
    }
}