using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace RaiteRaju.Entities
{
    [DataContract]
  public  class ContactUsEntity
    {
        [DataMember]
        public Int64 PhoneNumber { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string DtInserted { get; set; }
    }
}
