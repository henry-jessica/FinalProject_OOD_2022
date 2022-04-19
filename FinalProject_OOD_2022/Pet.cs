using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_OOD_2022
{
    //Enum of animal type 
    public enum DoctorSpeciality
    {
        Surgery,
        Nutrition,
        Bones,
        Anesthesia,
        Dentistry,
        Dermatology,
        Emergency,
        Ophthalmology,
        Pathology,

    }
    public enum PetType
    {
        Dog,
        Cat,
        Spider,
        Snake,
        Turtle,
        Fish,
        Hamster,
    }

    public enum GenderType
    {
        Male, 
        Female,
        Other
    }

    public enum OwnerStatus {
            Active ,
            Inactive,
        Blocked
    }
    public enum PetStatus {
    Alive, 
    Dead 
    }



    public class Pet
    {

        //create animal properties
        #region Properties
        [Key]
        public int PetID { get; set; }
        public string PetName { get; set; }
        public string PetImage { get; set; }
        public DateTime PetDBO { get; set; }
        public PetType PetType { get; set; }
        public virtual PetOwner PetOwner { get; set; }
        public string PetOwnerName { get; set; }
        public int OwnerID { get; set; }
        public string AppointmentTime { get; set; }
        public string AppointmentDoctor { get; set; }


        #endregion

    }
    //create owner properties - change this to external class later Jessica 
    public class PetOwner
    {
        [Key]
        public int OwnerID { get; set; }
        public string OwnerName { get; set; }
        public DateTime OwnerDBO { get; set; }
        public List<Pet> Pets { get; set; }
        public string Address { get; set; }


    }


    public class Address { 
    string AddressID { get; set; }
        string Street { get; set; }
        string Town { get; set; }
        string County { get; set; }
        string Country { get; set; }
        string ZipCode { get; set;  }
    }

    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DoctorSpeciality DoctorSpeciality { get; set; }
        public DateTime DBO { get; set; }
        public List<Pet> Pets { get; set; }
        public string Address { get; set; }

    }

    public class PetData : DbContext
    {
        public PetData() : base("PetDatabase5") { }
        public DbSet<PetOwner> PetOwner { set; get; }
        public DbSet<Pet> Pet { set; get; }
        public DbSet<Doctor> Doctor { set; get; }
    }
}
