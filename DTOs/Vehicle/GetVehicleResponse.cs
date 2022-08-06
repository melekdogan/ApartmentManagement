using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Vehicle
{
    public class GetVehicleResponse
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public Models.Entities.User User { get; set; }
    }
}
