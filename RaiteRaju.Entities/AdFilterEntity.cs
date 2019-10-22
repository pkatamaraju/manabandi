using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace RaiteRaju.Entities
{
    public class AdFilterEntity
    {
        [DataMember]
        public Int32 CategoryId { get; set; }
        [DataMember]
        public string txtState { get; set; }
        [DataMember]
        public string txtDistrict { get; set; }
        [DataMember]
        public string txtMandal { get; set; }

        [DataMember]
        public string TxtKeyWord { get; set; }
        [DataMember]
        public Int32 INTPAGENUMBER { get; set; }
        [DataMember]
        public Int32 INTPAGESIZE { get; set; }
        [DataMember]
        public Int32 SortValue { get; set; }


    }
}
