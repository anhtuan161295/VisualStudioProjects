using ASM_Ngay_1.Model;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ASM_Ngay_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //Hien thi du lieu tu data source vao ListView
            lvCategoryList.DataContext = CategoryData.CategoryList;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        //Su kien xay ra khi chon 1 category tren ListView
        private void lvCategoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Khoi dong storyboard de tao hieu ung hinh anh chi tiet category
            myStoryBoard.Begin();
        }
    }
}