﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.Web.Models
{
   public class VehicleFilterModel
    {
        public string VehicleID { get; set; }
        public string VehicleType { get; set; }
        public int? VehicleTypeID { get; set; }
        public string VehicleModel { get; set; }
        public string OwnerName { get; set; }
        public string VehicleNumber { get; set; }
        public string Place { get; set; }
        public Int32? intStateId { get; set; }
        public string intStateName { get; set; }
        public Int32? intDistrictId { get; set; }
        public string intDistrictName { get; set; }
        public Int32? intManadalID { get; set; }
        public string intManadalName { get; set; }
        public Int64 BigIntPhoneNumber { get; set; }
        public string TxtKeyWord { get; set; }
        public Int32 IntPageNumber { get; set; }
        public Int32 IntPageSize { get; set; }
        public Int32 SortValue { get; set; }
        public Int32 flgOnRide { get; set; }
        public Int32 intRideStatusID { get; set; }
        public int intOwnerID { get; set; }
        public int FlgAccountDeleted { get; set; }
        public decimal intRideAmount { get; set; }
        public decimal intRideCommision { get; set; }
        public decimal intRideKM { get; set; }
    }
}
