using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace RaiteRaju.Entities
{
   public class ReviewEntity
    {
        [DataMember]
        public Int64 PhoneNumber { get; set; }
        [DataMember]
        public string Review { get; set; }
        [DataMember]
        public string DtInserted { get; set; }
        [DataMember]
        public int FlgReviewVerified { get; set; }
    }
}
