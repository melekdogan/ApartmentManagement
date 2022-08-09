using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [ForeignKey("ApartmentId")]
        public int ApartmentId { get; set; } 
        public Apartment Apartment { get; set; }

        [ForeignKey("InvoiceTypeId")]
        public int InvoiceTypeId { get; set; }
        public InvoiceType InvoiceType { get; set; }

        public float InvoiceQuantity { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public bool IsPaid { get; set; } 

    }
}
