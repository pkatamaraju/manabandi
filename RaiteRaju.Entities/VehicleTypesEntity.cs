using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.Entities
{
   public class VehicleTypesEntity
    {
        public int intVehicleTypeId { get; set; }
        public string txtVehicleType { get; set; }
        public int intMileage { get; set; }
        public decimal intAverageFuelPrice { get; set; }
        public decimal intDriverSalary { get; set; }
        public decimal intAvgTollPrice { get; set; }
        public int intAverageSpeed { get; set; }
        public int intAvgWorkingHours { get; set; }
        public decimal intFuelCostPerKM { get; set; }
        public decimal intDriverCostPerKM { get; set; }
        public decimal intTotalCostPerKM { get; set; }
        public decimal BaseFare { get; set; }
    }
}
