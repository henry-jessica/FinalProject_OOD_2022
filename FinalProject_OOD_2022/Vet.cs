using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOD_2022
{
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
}
