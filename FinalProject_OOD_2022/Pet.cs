using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject_OOD_2022
{
    //Enums 
    public enum VetSpeciality
    {
        Surgery,
        Nutrition,
        Emergency,
        Ophthalmology,
        Pathology,

    }
    public enum AppointmentType
    {
        Routine,
        Emergency
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
    public enum ServiceStatus
    {
        Pendent,
        Paid
    }
    public enum AppointmentStatus
    {
        Completed,
        Pendent,
        Cancelled
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
        public Appointment Appointment { get; set; }
        #endregion

        //Methods 
        public override string ToString()
        {
            return $"#{PetID} - {PetName} {PetType.ToString().ToUpper()} {GenderType.ToString().ToUpper()}"; 
        }
    }
    public class PetOwner
    {
        [Key]
        public int OwnerID { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public DateTime OwnerDBO { get; set; }
        public List<Pet> Pets { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        [Key]
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
    }
        //Create Doctor Properties
    public class Vet
    {
        [Key]
        public int VetID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public VetSpeciality VetSpeciality { get; set; }
        public DateTime DBO { get; set; }
        public List<Appointment> Appointments { get; set; }

        public Address Address { get; set; }
    }


    public class Bill
    {
        [Key]
        public int billingId { get; set; }
        public double price { get; set; }
        public string Description { get; set; }
        public DateTime DatePayment { get; set; }
        public ServiceStatus StatusPayment { get; set; }
     //   public int VetID { get; set; }
        //public int OwnerID { get; set; }
     //   public int PetID { get; set; }
    //    public int AppointmentID { get; set; }
    }

    //Create Appintment Table 
    public class Appointment
    {
        [Key]
        public int ID { get; set; }
        public int PetID { get; set; }

        public int VetID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
       // public string Description { get; set; }
        public AppointmentStatus Status { get; set; }
        public AppointmentType Appointment_PathWay { get; set; }
        public Bill Bill { get; set; }
    }

    //Create Tables 
    public class PetData : DbContext
    {
        public PetData() : base("DataCreateFronted") { }
        public DbSet<PetOwner> PetOwner { set; get; }
        public DbSet<Pet> Pet { set; get; }
        public DbSet<Vet> Vet { set; get; }
        public DbSet<Bill> Bill { set; get; }

        public DbSet<Address> Address { get; set; }
        public DbSet<Appointment> Appointment { set; get; }

    }
}
