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
        List<Pet> allPets = new List<Pet>();
        List<Appointment> allAppointments = new List<Appointment>();
        PetData db = new PetData();


        public Home()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Pet
                        select p;


            allPets = query.ToList();
            lbxPet.ItemsSource = allPets;

        
            //Populate combobox
            cbxPetType.ItemsSource = new string[] { "All", "Cat", "Dog" };
            cbxPetType.SelectedIndex = 0;


            ViewPatient.Visibility = Visibility.Collapsed;
        }
        private void cbxPetType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Reset
            ResetViewPatientScreen();


            //All pets are displayed 
            ComboBox cbx = sender as ComboBox;
            string petTypeSelected = cbx.SelectedItem as string;


            if (petTypeSelected != null)
            {

                switch (petTypeSelected)
                {
                    case "Dog":
                        lbxPet.ItemsSource = allPets.Where(b => b.Type().Contains("Dog"));
                        break;
                    case "Cat":
                        lbxPet.ItemsSource = allPets.Where(b => b.Type().Contains("Cat"));
                        break;
                    default:
                        lbxPet.ItemsSource = allPets;
                        break;
                }
            }
        }
        private void blxPetChanged(object sender, SelectionChangedEventArgs e)
        {
            Pet petSelected = (Pet)lbxPet.SelectedItem;

            if (petSelected != null)
            {
                tblkPetDescription.Text = petSelected.PetDetailsRetrived();
                ImgPetImage.Source = new BitmapImage(new Uri(petSelected.PetImage));

                var query1 = from ap in db.Appointment
                             where ap.PetID == petSelected.PetID
                             select new
                             {
                                 VetID = ap.VetID,
                                 Date = ap.Date,
                                 Time = ap.Time,
                                 Appointment_PathWay = ap.Appointment_PathWay,
                             };

                Tbx_AppointmentDetails.ItemsSource = query1.ToList();
            }
        }

        //ViewBase Patient Screen
        private void Btn_Display_Patient(object sender, RoutedEventArgs e)
        {
            folder.Visibility = Visibility.Collapsed;
            ViewPatient.Visibility = Visibility.Visible;

        }
     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //exit button
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var query = from t in db.Pet
                        where t != null
                        select new
                        {
                            Name = t.PetName,

                        };
        }

        private void Appointment_Btn(object sender, RoutedEventArgs e)
        {
        }

        private void blxChanged(object sender, SelectionChangedEventArgs e)
        {


        }


        private void ViewAllBills(object sender, RoutedEventArgs e)
        {
            //Populate Patient List 
            var query1 = from b in db.Appointment
                         join b2 in db.Bill on b.Bill.billingId equals b2.billingId
                         join b3 in db.Pet on b.PetID equals b3.PetID
                         join b4 in db.PetOwner on b3.OwnerID equals b4.OwnerID
                         select b4;

            var query = from b in db.Bill

                         .Where(b => b.StatusPayment.ToString() == "Pendent")

                        select new
                        {
                            Name = b.StatusPayment

                        };
        }

        private void lbxPatient_SectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lbxBills_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewPatient.Visibility = Visibility.Collapsed;
            folder.Visibility = Visibility.Visible;

       
            ResetViewPatientScreen();
        }

        private void ResetViewPatientScreen()
        {
            tblkPetDescription.Text = "";
            ImgPetImage.Source = null;
            Tbx_AppointmentDetails.ItemsSource = null;
        }
    }
}
