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
        public string Forms { get; set; }
        public DateTime OwnerDBO { get; set; }
        public List<Pet> Pets { get; set; }

    }

    public class PetData : DbContext
    {
        public PetData() : base("PetDatabase4") { }
        public DbSet<PetOwner> PetOwner { set; get; }
        public DbSet<Pet> Pet { set; get; }
    }
}
