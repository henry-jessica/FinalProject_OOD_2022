using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<string> pets = new ObservableCollection<string>();
        public List<PetOwner> owners = new List<PetOwner>();

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
           // Folder.Visibility = Visibility.Collapsed;

            //var query = from t in db.Pet
            //            where t != null
            //            select new
            //            {
            //                Name = t.PetName,
            //               // Appoitment_Time = t.AppointmentTime,
            //            };
            //DgAppointments.ItemsSource = query.ToList();
        }

        private void Appointment_Btn(object sender, RoutedEventArgs e)
        {

            //var query = from p in db.Pet
            //            select p.PetName;

            //cbxPets.ItemsSource = query.ToList();


            //create new appointment 
            //Folder.Visibility = Visibility.Collapsed;
         //   DgCreateAppointments.ItemsSource = db.Pet.Where(p => p.AppointmentTime != null).ToList();
        }

        private void blxChanged(object sender, SelectionChangedEventArgs e)
        {
            //string petSelected = cbxPets.SelectedItem as string;

            //if (petSelected != null)
            //{
            //    var query = from d in db.Pet
            //                where d.PetName == petSelected
            //                select d.AppointmentTime;
            //    var petType = query.ToList();
            //    tbxPetDetails.Text = String.Format("Preis: {0}", petType[0]);

               

            //}




        }
    }
}
