using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalProject_OOD_2022
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {

        PetData db = new PetData();
        public Home()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
 



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //exit button
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Folder.Visibility = Visibility.Collapsed;

            var query = from t in db.Pet
                        where t.AppointmentTime != null
                        select new
                        {
                            Name = t.PetName,
                            Appoitment_Time = t.AppointmentTime,
                        };
            Appointments.ItemsSource = query.ToList();
        }

       
    }
}
