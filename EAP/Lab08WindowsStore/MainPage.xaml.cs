using Lab08WindowsStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab08WindowsStore
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

        private string url = "http://localhost:2060/api/Employees/";
        HttpClient httpClient = new HttpClient();

        private void loadData()
        {
            gvEmployee.ItemsSource = null;
            var model =
                JsonConvert.DeserializeObjectAsync<IEnumerable<Employee>>(httpClient.GetStringAsync(url).Result).Result;

            gvEmployee.ItemsSource = model;
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var emp = new Employee()
            {
                EmployeeName = txtName.Text,
                Age = int.Parse(txtAge.Text),
                Address = txtAddress.Text
            };

            var model = httpClient.PostAsJsonAsync(url, emp).Result;
            if (model.IsSuccessStatusCode)
            {
                await new MessageDialog("Add employee completed").ShowAsync();
                loadData();
            }
        }

        private void gvEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var emp = gvEmployee.SelectedItem as Employee;
            if (emp != null)
            {
                txtId.Text = emp.Id.ToString();
                txtName.Text = emp.EmployeeName;
                txtAge.Text = emp.Age.ToString();
                txtAddress.Text = emp.Address;
            }
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                await new MessageDialog("Id invalid").ShowAsync();
            }
            else
            {
                var emp = new Employee()
                {
                    Id = int.Parse(txtId.Text),
                    EmployeeName = txtName.Text,
                    Age = int.Parse(txtAge.Text),
                    Address = txtAddress.Text
                };

                var model = httpClient.PutAsJsonAsync(url, emp).Result;
                if (model.IsSuccessStatusCode)
                {
                    await new MessageDialog("Update employee completed").ShowAsync();
                    loadData();
                }
                else if (model.StatusCode == HttpStatusCode.NotFound)
                {
                    await new MessageDialog("Employee not found").ShowAsync();
                }
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                await new MessageDialog("Id invalid").ShowAsync();
            }
            else
            {
                int id = int.Parse(txtId.Text);

                var model = httpClient.DeleteAsync(url + id).Result;
                if (model.IsSuccessStatusCode)
                {
                    await new MessageDialog("Delete employee completed").ShowAsync();
                    loadData();
                }
                else if (model.StatusCode == HttpStatusCode.NotFound)
                {
                    await new MessageDialog("Employee not found").ShowAsync();
                }
            }
        }
    }
}