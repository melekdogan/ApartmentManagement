using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class InvoiceType
    {
        [Key]
        public int InvoiceTypeId { get; set; }
        public string InvoiceTypeName { get; set; }
    }
}
