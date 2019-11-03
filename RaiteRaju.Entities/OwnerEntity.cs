using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.Entities
{
   public class OwnerEntity
    {
        public string txtOwnerName { get; set; }
        public string txtPlace { get; set; }
        public string txtPassword { get; set; }
        public Int32 intStateId { get; set; }
        public Int32 intDistrictId { get; set; }
        public Int32 intManadalID { get; set; }
        public Int64 BigIntPhoneNumber { get; set; }
        public int OTP { get; set; }
    }
}
