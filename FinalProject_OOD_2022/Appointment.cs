using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOD_2022
{
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

        public string Appointment_Color
        {
            
            get
            {
                return "Red";
                // if (Appointment_PathWay.ToString() == "Emergency")

                //else
                //    return "Blue"; 
            }
        }

    }

}
