using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_OOD_2022
{
    //Enums 
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
        //Fish,
        //Hamster,
    }
    public enum GenderType
    {
        Male,
        Female
    }
    public enum OwnerStatus
    {
        Active,
        Inactive,
        Blocked
    }
    public enum PetStatus
    {
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
        public int OwnerID { get; set; }
        public GenderType GenderType { get; set; }
        #endregion
    }
    //create owner properties - change this to external class later 
    public class PetOwner
    {
        [Key]
        public int OwnerID { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName{ get; set; }
        public DateTime OwnerDBO { get; set; }
        public List<Pet> Pets { get; set; }
        //public Address Address { get; set; }
    }

    //Create Address Properties
    //public class Address
    //{
    //    [Key]
    //    string AddressID { get; set; }
    //    string Street { get; set; }
    //    string Town { get; set; }
    //    string County { get; set; }
    //    string Country { get; set; }
    //    string ZipCode { get; set; }
    //}

    //Create Doctor Properties
    //public class Doctor
    //{
    //    [Key]
    //    public int DoctorID { get; set; }
    //    public string FirstName { get; set; }
    //    public string SecondName { get; set; }
    //    public DoctorSpeciality DoctorSpeciality { get; set; }
    //    public DateTime DBO { get; set; }
    //    public List<Pet> Pets { get; set; }
    //    public string Address { get; set; }
    //    //public Address DocAddress { get; set; }
    //}
    //Create Appintment Table 
    //public class Appointment
    //{
    //    [Key]
    //    public int ID { get; set; }
    //    public Pet PetID { get; set; }
    //  //  public Doctor DoctorID { get; set; }
    //    public DateTime Date { get; set; }
    //}

    //Create Tables
    public class PetData : DbContext
    {
        public PetData() : base("PetDatabase9") { }
        public DbSet<PetOwner> PetOwner { set; get; }
        public DbSet<Pet> Pet { set; get; }
       // public DbSet<Doctor> Doctor { set; get; }
        //public DbSet<Address> Address { set; get; }

    }
}
