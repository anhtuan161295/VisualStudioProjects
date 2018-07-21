using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Module03.model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Module03
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            gvCar.ItemsSource = model.Car.CarDataSource.cList;
        }

        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var car = model.Car.CarDataSource.cList.SingleOrDefault(c => c.Make.Equals(txtMake.Text));
            if (car == null)
            {
                await new Windows.UI.Popups.MessageDialog("Car is not exist").ShowAsync();
            }
            else
            {
                car.Model=txtModel.Text;
                car.YearOfRes=txtYOR.Text;
                car.AddOn=txtAO.Text;
                car.RenPerDay=double.Parse(txtRPD.Text);

                await new Windows.UI.Popups.MessageDialog("Update successful").ShowAsync();
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
             var car = model.Car.CarDataSource.cList.SingleOrDefault(c => c.Make.Equals(txtMake.Text));
            if (car == null)
            {
                await new Windows.UI.Popups.MessageDialog("Car is not exist").ShowAsync();
            }
            else
            {
                
                model.Car.CarDataSource.cList.Remove(car);
                await new Windows.UI.Popups.MessageDialog("Delete successful").ShowAsync();
            }
        }

        //private async void btnCreate_Click(object sender, RoutedEventArgs e)
        //{       
        //        model.Car.CarDataSource.cList.Add(1);
                
        //        Model=txtModel.Text;
        //        YearOfRes=txtYOR.Text;
        //        AddOn=txtAO.Text;
        //        RenPerDay=double.Parse(txtRPD.Text);

        //        await new Windows.UI.Popups.MessageDialog("Update successful").ShowAsync();
        //}
        }
    }

