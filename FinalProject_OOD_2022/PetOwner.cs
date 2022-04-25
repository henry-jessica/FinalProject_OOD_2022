using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOD_2022
{
    public class PetOwner
    {
        [Key]
        public int OwnerID { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public DateTime OwnerDBO { get; set; }
        public List<Pet> Pets { get; set; }

        public Address Address { get; set; }


        public string RetriveOwnerName()
        {
            return OwnerFirstName + " " + OwnerLastName;
        }

        public override string ToString()
        {
            return $"#{OwnerID} - {OwnerFirstName} {OwnerLastName}"; 
        }


    }

    

}
