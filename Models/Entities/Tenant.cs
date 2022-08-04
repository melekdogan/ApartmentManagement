using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Tenant
    {
        [Key]
        public int TenantId { get; set; }

        [ForeignKey("ApartmentId")]
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }


    }
}
