using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Module01
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Calculator : Page
    {
        private string str;

        public Calculator()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string s = e.Parameter as string;
            string name;
            if (string.IsNullOrEmpty(s))
            {
                name = "Guest";
            }
            else
            {
                name = s;
            }
            txtTextBlock.Text = "Welcome to " + name;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null);
        }

        private void writeNum(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            str += btn.Content.ToString();
            TxtCal.Text = str;
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            string s = TxtCal.Text;

            if (string.IsNullOrEmpty(s) == false & s.Length >= 3)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].Equals('+'))
                    {
                        string firstNum = s.Remove(i); //Lấy số trước dấu +
                        string secondNum = s.Substring(i + 1); //Lấy số sau dấu +
                        double a = double.Parse(firstNum); //Chuyển qua double
                        double b = double.Parse(secondNum);
                        double c = a + b; //Cộng 2 số
                        TxtCal.Text = c.ToString(); //Xuất ra text box
                    }
                    if (s[i].Equals('-'))
                    {
                        string firstNum = s.Remove(i); //Lấy số trước dấu +
                        string secondNum = s.Substring(i + 1); //Lấy số sau dấu +
                        double a = double.Parse(firstNum); //Chuyển qua double
                        double b = double.Parse(secondNum);
                        double c = a - b; //Cộng 2 số
                        TxtCal.Text = c.ToString(); //Xuất ra text box
                    }
                    if (s[i].Equals('*'))
                    {
                        string firstNum = s.Remove(i); //Lấy số trước dấu +
                        string secondNum = s.Substring(i + 1); //Lấy số sau dấu +
                        double a = double.Parse(firstNum); //Chuyển qua double
                        double b = double.Parse(secondNum);
                        double c = a * b; //Cộng 2 số
                        TxtCal.Text = c.ToString(); //Xuất ra text box
                    }
                    if (s[i].Equals('/'))
                    {
                        string firstNum = s.Remove(i); //Lấy số trước dấu +
                        string secondNum = s.Substring(i + 1); //Lấy số sau dấu +
                        double a = double.Parse(firstNum); //Chuyển qua double
                        double b = double.Parse(secondNum);
                        double c = a / b; //Cộng 2 số
                        TxtCal.Text = c.ToString(); //Xuất ra text box
                    }
                }
            }
        }

        private void clearNum(object sender, RoutedEventArgs e)
        {
            TxtCal.Text = "0";
            str = "";
        }
    }
}