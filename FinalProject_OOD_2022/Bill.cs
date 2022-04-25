using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOD_2022
{
    public class Bill
    {
        [Key]
        public int billingId { get; set; }
        public double price { get; set; }
        public string Description { get; set; }
        public DateTime DatePayment { get; set; }
        public PaymentStatus StatusPayment { get; set; }

        public override string ToString()
        {
            return $"€: {price}  Due:{DatePayment} Status:{StatusPayment.ToString()}"; 
        }
    }
    
}
