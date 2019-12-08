﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.Entities
{
    public class RideEntity
    {
        public string Name { get; set; }
        public Int64 PhoneNumber { get; set; }
        public int VehicleTypeID { get; set; }
        public string VehicleType { get; set; }
        public string PickUpLocation { get; set; }
        public string DropLocation { get; set; }
        public Int32 OTP { get; set; }
        public string Password { get; set; }
        public string DtCreated { get; set; }
        public string dtScheduledDate { get; set; }
        public string txtScheduledTime { get; set; }
        public string ExistingUserOrNot { get; set; }
        public int intRideID { get; set; }
        public string txtRideStatus { get; set; }
        public string txtVehicleNumber { get; set; }
        public decimal intRideAmount { get; set; }
        public decimal intRideCommision { get; set; }
        public decimal intRideKM { get; set; }
    }
}
