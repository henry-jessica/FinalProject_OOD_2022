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
    public enum PaymentStatus
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

        public override string ToString()
        {
            return $"#{PetID} - {PetName}";
        }
        public string Type()
        {
            return PetType.ToString(); 
        }

        public string PetDetailsRetrived()
        {
            return $"Name: {PetName} {PetOwner.OwnerLastName}\nDOB: {PetDBO.ToString("dd/MM/yyyy")}" +
                   $"\nType: {PetType}\nOwner: {PetOwner.OwnerFirstName} {PetOwner.OwnerLastName}"; 
        }

    }

    //Create Tables 
    public class PetData : DbContext
    {
        public PetData() : base("DataCreateFrontendTest2") { }
        public DbSet<PetOwner> PetOwner { set; get; }
        public DbSet<Pet> Pet { set; get; }
        public DbSet<Vet> Vet { set; get; }
        public DbSet<Bill> Bill { set; get; }

        public DbSet<Address> Address { get; set; }
        public DbSet<Appointment> Appointment { set; get; }

    }
}
