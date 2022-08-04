using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public User User { get; set; }
    }
}
