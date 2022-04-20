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
    }
    public class PetOwner
    {
        [Key]
        public int OwnerID { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public DateTime OwnerDBO { get; set; }
        //public List<Pet> Pets { get; set; }
        //public string Phone { get; set; }
        // public Service Service { get; set; }
    }

    //public class Address
    //{
    //    [Key]
    //    string ZipCode { get; set; }
    //    string Street { get; set; }
    //    string Town { get; set; }
    //    string County { get; set; }
    //    string Country { get; set; }
    //    public Vet Vet { get; set; }
    //}

    //Create Doctor Properties
    public class Vet
    {
        [Key, Column(Order = 1)]
        public int VetID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public VetSpeciality VetSpeciality { get; set; }
        public DateTime DBO { get; set; }
        public List<Appointment> Appointments { get; set; }
    }


    public class Bill
    {
        [Key]
        public int billingId { get; set; }
        public double price { get; set; }
        public string Description { get; set; }
        public DateTime DatePayment { get; set; }
        public ServiceStatus StatusPayment { get; set; }
        public int VetID { get; set; }
        public int OwnerID { get; set; }
        public int PetID { get; set; }
        public int AppointmentID { get; set; }
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
        public string Description { get; set; }
        public AppointmentStatus Status { get; set; }
        public AppointmentType Appointment_PathWay { get; set; }


    }

    //Create Tables 
    public class PetData : DbContext
    {
        public PetData() : base("PetDatabase200422") { }
        public DbSet<PetOwner> PetOwner { set; get; }
        public DbSet<Pet> Pet { set; get; }
        public DbSet<Vet> Vet { set; get; }

        public DbSet<Bill> Bill { set; get; }
        public DbSet<Appointment> Appointment { set; get; }

    }
}
