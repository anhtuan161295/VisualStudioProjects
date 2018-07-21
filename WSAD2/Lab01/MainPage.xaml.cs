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

namespace Lab01
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse
            {
                Fill =  new SolidColorBrush(Windows.UI.Colors.Red),
                Width = 100,
                Height = 100,
                Margin = new Thickness(10)
            };

            itemControl.Items.Add(ellipse);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (itemControl.Items.Count > 0)
            {
                itemControl.Items.RemoveAt(0);
            }
            else
            { 
                //nothing to do
            }
        }

        private void myImg_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            fadeIn.Begin();
        }

        private void myImg_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            fadeOut.Begin();
        }

        private void imgG_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var image = (CompositeTransform)imgG.RenderTransform;
            image.TranslateX += e.Delta.Translation.X;
            image.TranslateY += e.Delta.Translation.Y;
        }
    }
}
