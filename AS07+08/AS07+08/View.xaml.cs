using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AS07_08
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class View : Page
    {
        public View()
        {
            this.InitializeComponent();
            gvComputers.ItemsSource = ComputerData.cList;
        }

        private void gvComputers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Computer com = gvComputers.SelectedItem as Computer;
            ObservableCollection<Computer> newList = new ObservableCollection<Computer>();
            newList.Add(com);
            lvDetails.ItemsSource = newList;
        }
    }
}