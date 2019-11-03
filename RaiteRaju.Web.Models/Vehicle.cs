using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.Web.Models
{
   public class Vehicle
    {
        public string intOwnerID { get; set; }
        public Int32 intVehicleTypeID { get; set; }

        public string txtVehicleName { get; set; }
        public Int64 BigIntPhoneNumber { get; set; }
        public string txtVehicleNumber { get; set; }
    }
}
