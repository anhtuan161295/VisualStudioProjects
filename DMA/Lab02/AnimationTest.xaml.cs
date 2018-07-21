using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Lab02
{
    public partial class AnimationTest : PhoneApplicationPage
    {
        public AnimationTest()
        {
            InitializeComponent();
        }

        DispatcherTimer dt = new DispatcherTimer();
        Random rd = new Random();

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Start();
            dt.Tick += dt_Tick;
        }

        void dt_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ellipse.RenderTransform = new TranslateTransform()
            {
                X = rd.Next(1, 310),
                Y = rd.Next(1, 310)
            };
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ellipse.RenderTransform = new TranslateTransform()
            {
                X = rd.Next(1, 290),
                Y = rd.Next(1, 290)
            };
        }
    }
}