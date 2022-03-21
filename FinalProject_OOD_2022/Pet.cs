using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public int PetID { get; set; }
        public string PetName { get; set; }
        public string PetImage { get; set; }
        public DateTime PetDBO { get; set; }
        public PetType PetType { get; set; }

        public virtual PetOwner PetOwner { get; set; }

        public string PetOwnerName { get; set; }

        public int PetOwnerID { get; set; }


        #endregion

        //default Constructors
        public Pet() { }
    }


    //create owner properties - change this to external class later Jessica 
    public class PetOwner
    {
        public int OwnerID { get; set; }
        public string OwnerName { get; set; }
        public string Forms { get; set; }
        public DateTime OwnerDBO { get; set; }
        public List<Pet> Pets { get; set; }

    }

    public class PetData : DbContext
    {
        public PetData() : base("PetDatabase1") { }
        public DbSet<Pet> Pet { set; get; }
        public DbSet<PetOwner> PetOwner { set; get; }
    }
}
