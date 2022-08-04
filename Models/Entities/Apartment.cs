using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public string Block { get; set; }
        public bool IsFilled { get; set; } 
        public string TypeOf { get; set; }
        public sbyte Floor { get;set; }
        public byte ApartmentNo { get; set; }
        public ICollection<Tenant> Tenants { get; set; }
    }
}
