using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FinalProject_OOD_2022
{
    /// <summary>
    /// Interaction logic for loading.xaml
    /// </summary>
    public partial class loading : Window
    {
        private int time = 2;
        private DispatcherTimer Timer;

        public loading()
        {
            InitializeComponent();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick; 
            Timer.Start();

        }
        void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 10)
            {
                time--;
            }
            else
            {
                img.Visibility = Visibility.Visible;

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //show img1 
            //count 1 second 
            //hide img1
        }

    }
}
