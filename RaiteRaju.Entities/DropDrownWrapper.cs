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
    public class DropDrownWrapper
    {
        [DataMember]
        public List<GDictionary> DistrctList { get; set; }
        [DataMember]
        public List<GDictionary> MandalList { get; set; }
    }
}
