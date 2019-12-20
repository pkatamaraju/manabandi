using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.Entities
{
    public class PriceMultipleEntity
    {
        public int intVehicleTypeID { get; set; }
        public int intKMRange { get; set; }
        public string txtVehicleType { get; set; }
        public decimal intPriceMultiple { get; set; }
        public int IntPricePK { get; set; }
        public decimal intPricePerKM { get; set; }
    }
}
