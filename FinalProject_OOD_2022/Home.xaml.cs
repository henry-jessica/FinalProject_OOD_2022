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
        List<PetOwner> ClientsSpecialOffer = new List<PetOwner>();
        List<Pet> petsSelected = new List<Pet>();
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
            cbxFinanceSituation.ItemsSource = new string[] { "All", "Paid", "Pendent" };
            cbxPetType.SelectedIndex = 0;


            ViewPatient.Visibility = Visibility.Collapsed;
            ViewFinance.Visibility = Visibility.Collapsed;
            CreatePatient.Visibility = Visibility.Collapsed; 

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
        private void ViewAllBills(object sender, RoutedEventArgs e)
        {

            var query = from p in db.Pet
                        join ap in db.Appointment on p.PetID equals ap.PetID
                        orderby p.PetOwner.OwnerFirstName ascending
                        select new
                        {
                            Name = p.PetOwner,
                            Surname = p.PetOwner.OwnerLastName
                        };

            lbxOwner.ItemsSource = query.ToList().Distinct();

            //Clean Screen 
            ViewFinance.Visibility = Visibility.Visible;
            ViewPatient.Visibility = Visibility.Collapsed;
            folder.Visibility = Visibility.Collapsed;

        }

        //ViewBase Patient Screen
        private void Btn_Display_Patient(object sender, RoutedEventArgs e)
        {
            folder.Visibility = Visibility.Collapsed;
            ViewFinance.Visibility = Visibility.Collapsed;
            ViewPatient.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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

        private void blxOwnerChanged(object sender, SelectionChangedEventArgs e)
        {
            //PetOwner OwnerSelected = (PetOwner)lbxOwner.SelectedItem;
            //if (OwnerSelected != null)
            //{
            //    // tblkOwnerDescription.Text = OwnerSelected.FullDescription();
            //}
        }

        private void CreateNewPatient(object sender, RoutedEventArgs e)
        {

            ViewPatient.Visibility = Visibility.Collapsed;
            folder.Visibility = Visibility.Collapsed;
            CreatePatient.Visibility = Visibility.Visible;

        }
        //Create a new Customer 
        //Create a new Pet
        //Create a new appointment 
        //Give special Offer to Appointment 
        private void btn_SaveOwner(object sender, RoutedEventArgs e)
        {
            //        string name = tbxName.Text;
            //        PetOwner customer = new PetOwner
            //        {
            //            OwnerFirstName = tbxName.Text,
            //    //        OwnerLastName = tbxSurname.Text,
            //    //        OwnerDBO = tbxDOB.Text, 
            //    //        public List<Pet> Pets { get; set; }
            //    //        public Address Address { get; set; }
            //};
        }

        private void PaymentStatus_Changed(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            string BillSituationSelected = cbx.SelectedItem as string;

            var query = from p in db.Pet
                        join ap in db.Appointment on p.PetID equals ap.PetID
                        orderby p.PetOwner.OwnerFirstName ascending
                        select new
                        {
                            ap.Bill.StatusPayment,
                            Name = p.PetOwner
                        };

            if (BillSituationSelected != null)
            {

                switch (BillSituationSelected)
                {
                    case "Paid":
                        lbxOwner.ItemsSource = query.ToList().Where(b => b.StatusPayment.ToString().Contains("Paid"));
                        break;
                    case "Pendent":
                        lbxOwner.ItemsSource = query.ToList().Where(b => b.StatusPayment.ToString().Contains("Pendent"));
                        break;
                    default:
                        lbxPet.ItemsSource = query.ToList();
                        break;
                }
            }
        }

        private void btnMoreDetailsBill(object sender, RoutedEventArgs e)
        {

            //All pets are displayed 
            var selectedItem = lbxOwner.SelectedItem;  //as PetOwner;

            if (selectedItem != null)
            {

            }
        }
    }
}
